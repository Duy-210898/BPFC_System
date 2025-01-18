using BFPC_System;
using Microsoft.Office.Interop.Outlook;
using System;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using Excel = Microsoft.Office.Interop.Excel;
using DevExpress.XtraPrinting.Native;
using OfficeOpenXml.Table.PivotTable;
using System.Collections.Generic;



namespace BPFC_System
{

    public partial class DataShow : UserControl
    {
        private readonly DailyReport createDailyControl;
        public DataShow()
        {
            InitializeComponent();
            createDailyControl = new DailyReport();
            this.DoubleBuffered = true;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // Tạo các màu cho gradient
            Color color1 = Color.Black; // Màu đen
            Color color2 = Color.Navy; // Màu navy
            Color color3 = Color.DarkBlue; // Màu xanh

            // Tạo một LinearGradientBrush
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, color1, color1, LinearGradientMode.Horizontal))
            {
                ColorBlend colorBlend = new ColorBlend();
                colorBlend.Colors = new Color[] { color1, color2, color3, color2 }; // Thứ tự màu sắc
                colorBlend.Positions = new float[] { 0.0f, 0.4f, 0.6f, 1.0f };

                brush.InterpolationColors = colorBlend;

                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private string FindDefaultAttachment()
        {
            string defaultAttachmentPath = string.Empty;
            string folderPath = @"D:\Report";
            string searchPattern = "Daily-Report-BPFC Compliance Checklist*";

            try
            {
                DirectoryInfo directory = new DirectoryInfo(folderPath);

                FileInfo[] files = directory.GetFiles(searchPattern)
                    .OrderByDescending(f => f.LastWriteTime)
                    .ToArray();

                if (files.Length > 0)
                {
                    defaultAttachmentPath = files[0].FullName;
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm đính kèm mặc định: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return defaultAttachmentPath;
        }

        private string GenerateDefaultSubject()
        {
            DateTime currentDate = DateTime.Now;

            int daysToSubtract = currentDate.DayOfWeek == DayOfWeek.Monday ? 2 : 1;
            DateTime adjustedDate = currentDate.AddDays(-daysToSubtract);

            string formattedDate = adjustedDate.ToString("MMMM dd");

            if (adjustedDate.Day % 10 == 1 && adjustedDate.Day != 11)
            {
                formattedDate += "st";
            }
            else if (adjustedDate.Day % 10 == 2 && adjustedDate.Day != 12)
            {
                formattedDate += "nd";
            }
            else if (adjustedDate.Day % 10 == 3 && adjustedDate.Day != 13)
            {
                formattedDate += "rd";
            }
            else
            {
                formattedDate += "th";
            }

            return formattedDate;
        }

        private void ComposeEmail(string defaultAttachmentPath)
        {
            string defaultSubjectDate = GenerateDefaultSubject();

            try
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
                MailItem mailItem = (MailItem)outlookApp.CreateItem(OlItemType.olMailItem);

                SetMailItemProperties(mailItem, defaultSubjectDate, defaultAttachmentPath);
                SetMailRecipients(mailItem);

                Excel.Application excelApp = new Excel.Application();
                Excel.Workbook workbook = excelApp.Workbooks.Open(defaultAttachmentPath);
                Excel.Worksheet worksheet = workbook.Sheets["Daily Report"];
                Excel.Range range = worksheet.UsedRange;

                StringBuilder emailBody = new StringBuilder();

                string valueInF5 = ScanAndSaveF5Value(range);
                List<string> failCellValues = GetCellValuesInColumn2ForFailRows(worksheet);

                string emailText = ComposeEmailText(defaultSubjectDate, valueInF5, failCellValues);

                SetEmailBodyAndDisplay(mailItem, range, emailBody, emailText);

                CloseExcelApplication(workbook, excelApp);

                mailItem.Display();
            }

            catch (System.Exception ex)
            {
                HandleError(ex);
            }
        }
        private bool fileErrorHandled = false;

        private void HandleFileNotFoundError(string defaultAttachmentPath)
        {
            DialogResult result = MessageBox.Show("Không tìm thấy File báo cáo.\nHãy xuất File trước khi gửi Mail!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                frmReport frmReport = new frmReport();
                frmReport.Show();
                frmReport.ExportDataToExcel(() =>
                {
                    fileErrorHandled = true;
                    if (!string.IsNullOrEmpty(defaultAttachmentPath) && File.Exists(defaultAttachmentPath))
                    {
                        ComposeEmail(defaultAttachmentPath);
                    }
                });
            }
        }

        private void btnComposeEmail_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                string defaultAttachmentPath = FindDefaultAttachment();
                bool fileError = string.IsNullOrEmpty(defaultAttachmentPath) || !File.Exists(defaultAttachmentPath);

                if (fileError)
                {
                    HandleFileNotFoundError(defaultAttachmentPath);
                }
                else
                {
                    ComposeEmail(defaultAttachmentPath);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default; 
            }
        }
        private void SetMailRecipients(MailItem mailItem)
        {
            string toEmailsFilePath = "D:/Audit System/ToEmails.txt";
            string ccEmailsFilePath = "D:/Audit System/CcEmails.txt";

            if (File.Exists(toEmailsFilePath) && File.Exists(ccEmailsFilePath))
            {
                string toEmails = File.ReadAllText(toEmailsFilePath);
                string ccEmails = File.ReadAllText(ccEmailsFilePath);

                string[] toEmailArray = toEmails.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
                string[] ccEmailArray = ccEmails.Split(new[] { ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

                mailItem.To = toEmailArray.Length > 0 ? string.Join(";", toEmailArray) + ";" : "";
                mailItem.CC = ccEmailArray.Length > 0 ? string.Join(";", ccEmailArray) + ";" : "";
            }
            else
            {
                MessageBox.Show($"Không tìm thấy file danh sách Mail!\nHãy kiểm tra D:/Audit System", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SetMailItemProperties(MailItem mailItem, string defaultSubjectDate, string defaultAttachmentPath)
        {
            mailItem.Subject = $"BPFC compliance daily report on {defaultSubjectDate}";
            mailItem.Attachments.Add(defaultAttachmentPath);
        }

        private string ComposeEmailText(string defaultSubjectDate, string valueInF5, List<string> failCellValues)
        {
            string case1Text = "Dear all,<br>" +
                $"I would like to send out the BPFC compliance on {defaultSubjectDate} is {valueInF5}.<br>" +
                "Thank you so much. <br> " +
                "<br> " +
                "This email is automatically generated, you do not need to reply. <br>" +
                "If there are any problems, please contact via email Lily-Nguyen@vn.apachefootwear.com ";

            string case2Text;
            if (failCellValues.Count == 1)
            {
                case2Text = "Dear all,<br>" +
                    $"I would like to send out the BPFC compliance on {defaultSubjectDate} is {valueInF5}.<br>" +
                    $"In this report, there is one line that is Fail ({string.Join(", ", failCellValues)}).<br>" +
                    "Please note!<br>" +
                    "Thank you so much. <br>" +
                    "<br> " +
                    "This email is automatically generated, you do not need to reply. <br>" +
                    "If there are any problems, please contact via email Lily-Nguyen@vn.apachefootwear.com ";
            }
            else if (failCellValues.Count > 1)
            {
                case2Text = "Dear all,<br>" +
                    $"I would like to send out the BPFC compliance on {defaultSubjectDate} is {valueInF5}.<br>" +
                    $"In this report, there are {failCellValues.Count} lines that are Fail ({string.Join(", ", failCellValues)}).<br>" +
                    "Please note!<br>" +
                    "Thank you so much. <br>" +
                    "<br> " +
                    "This email is automatically generated, you do not need to reply. <br>" +
                    "If there are any problems, please contact via email Lily-Nguyen@vn.apachefootwear.com ";
            }
            else
            {
                case2Text = "Dear all,<br>" +
                    $"I would like to send out the BPFC compliance on {defaultSubjectDate} is {valueInF5}.<br>" +
                    "Thank you so much. <br>" +
                    "<br> " +
                    "This email is automatically generated, you do not need to reply. <br>" +
                    "If there are any problems, please contact via email Lily-Nguyen@vn.apachefootwear.com ";
            }

            return (valueInF5.Equals("100%", StringComparison.OrdinalIgnoreCase) || valueInF5.Equals("100.0%", StringComparison.OrdinalIgnoreCase)) ? case1Text : case2Text;
        }

        private void SetEmailBodyAndDisplay(MailItem mailItem, Excel.Range range, StringBuilder emailBody, string emailText)
        {
            emailBody.Append($"<p>{emailText}</p>");
            BuildEmailBody(range, emailBody);
            mailItem.HTMLBody = emailBody.ToString();
        }

        private void CloseExcelApplication(Excel.Workbook workbook, Excel.Application excelApp)
        {
            workbook.Close(false);
            excelApp.Quit();
        }
        private List<string> GetCellValuesInColumn2ForFailRows(Excel.Worksheet worksheet)
        {
            List<int> failRowIndices = FindRowIndicesForFail(worksheet);
            List<string> cellValuesInColumn2 = new List<string>();

            foreach (int failRowIndex in failRowIndices)
            {
                object cellValue = worksheet.Cells[failRowIndex, 2].Value;

                if (cellValue != null)
                {
                    cellValuesInColumn2.Add(cellValue.ToString());
                }
            }

            return cellValuesInColumn2;
        }

        private List<int> FindRowIndicesForFail(Excel.Worksheet worksheet)
        {
            List<int> failRowIndices = new List<int>();

            // Duyệt qua từng dòng để tìm chữ "FAIL" trong cột 6
            for (int row = 1; row <= worksheet.UsedRange.Rows.Count; row++)
            {
                object cellValue = worksheet.Cells[row, 6].Value;

                // Kiểm tra nếu ô chứa chữ "FAIL"
                if (cellValue != null && cellValue.ToString().Equals("FAIL", StringComparison.OrdinalIgnoreCase))
                {
                    failRowIndices.Add(row); // Thêm chỉ số dòng chứa "FAIL" vào danh sách
                }
            }

            return failRowIndices;
        }
        private string ScanAndSaveF5Value(Excel.Range range)
        {
            // Lấy giá trị từ ô F5
            Excel.Range cellF5 = range.Cells[5, 6];
            object valueInF5 = cellF5.Value;

            // Kiểm tra nếu giá trị không phải DBNull.Value
            if (valueInF5 != null && valueInF5 != DBNull.Value)
            {
                return valueInF5.ToString();
            }
            return string.Empty;
        }

        private void BuildEmailBody(Excel.Range range, StringBuilder emailBody)
        {
            emailBody.Append("<table style='border-collapse: collapse; width: 700px;'>");

            emailBody.Append("<colgroup>");

            for (int i = 1; i <= range.Columns.Count; i++)
            {
                emailBody.Append("<col style='width: auto;'>");
            }

            emailBody.Append("</colgroup>");

            for (int row = 4; row <= range.Rows.Count; row++)
            {
                emailBody.Append("<tr>");

                for (int col = 1; col <= range.Columns.Count; col++)
                {
                    object cellValue = range.Cells[row, col].Value;

                    if (cellValue != null && cellValue != DBNull.Value)
                    {
                        SetCellAttributes(range, emailBody, row, col, cellValue);
                    }
                    else
                    {
                        emailBody.Append("<td></td>");
                    }
                }

                emailBody.Append("</tr>");
            }
            emailBody.Append("</table>");
        }
        private void SetCellAttributes(Excel.Range range, StringBuilder emailBody, int row, int col, object cellValue)
        {
            var cellInteriorColor = ((Range)range.Cells[row, col]).Interior.Color;
            string hexColor = ColorTranslator.ToHtml(System.Drawing.ColorTranslator.FromOle((int)cellInteriorColor));

            var fontColor = ((Range)range.Cells[row, col]).Font.Color;
            string hexFontColor = ColorTranslator.ToHtml(System.Drawing.ColorTranslator.FromOle((int)fontColor));

            var cellBorders = ((Range)range.Cells[row, col]).Borders;
            string borderStyle = "solid";

            // Lấy kích thước của cột (width) trong đơn vị đo độ rộng của một ký tự
            double columnWidth = range.Columns[col].ColumnWidth;

            if (col == 1)
            {
                // Sửa đổi để thêm màu chữ và kích thước của cột
                emailBody.AppendFormat("<td colspan='6' style='background-color:{1}; color:{3}; border: 1px {2} #000; width: {4}px;'>{0}</td>", cellValue.ToString(), hexColor, borderStyle, hexFontColor, columnWidth);
            }
            else
            {
                // Sửa đổi để thêm màu chữ và kích thước của cột
                emailBody.AppendFormat("<td style='background-color:{1}; color:{3}; border: 1px {2} #000; width: {4}px;'>{0}</td>", cellValue.ToString(), hexColor, borderStyle, hexFontColor, columnWidth);
            }
        }

        private void HandleError(System.Exception ex)
        {
            MessageBox.Show($"Error composing email: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        private void btnDaily_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu đang hiển thị ucCreateUsers thì không cần làm gì
            if (!splManage.Panel2.Controls.Contains(createDailyControl))
            {
                splManage.Panel2.Controls.Clear();
                createDailyControl.Dock = DockStyle.Fill;
                splManage.Panel2.Controls.Add(createDailyControl);
            }
        }

        private frmReport reportForm;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnViewExport_Click(object sender, EventArgs e)
        {
            if (reportForm == null || reportForm.IsDisposed)
            {
                reportForm = new frmReport();

                reportForm.ShowHomeButton = false;

                reportForm.Show();
            }
            else
            {
                if (reportForm.WindowState == FormWindowState.Minimized)
                {
                    reportForm.WindowState = FormWindowState.Normal;
                }

                reportForm.BringToFront();
                reportForm.Focus();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataShow_Load(object sender, EventArgs e)
        {
            BeginInvoke(new System.Action(() =>
            {
                splManage.Panel2.Controls.Clear();
                createDailyControl.Dock = DockStyle.Fill;
                splManage.Panel2.Controls.Add(createDailyControl);
            }));
        }
        private void btnRandomCheck_Click(object sender, EventArgs e)
        {
            frmRandomCheck randomCheckForm = new frmRandomCheck();
            randomCheckForm.Show();
        }
    }
}