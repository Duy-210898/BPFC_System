﻿using DevExpress.XtraEditors;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using BFPC_System;
using System.Threading.Tasks;
using System.Linq;

namespace BPFC_System
{
    public partial class frmBpfc : XtraForm
    {
        private readonly string connectionString;
        private DateTime lastLogTime = DateTime.Now;
        public frmBpfc()
        {
            InitializeComponent(); 

            connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
            DoubleBuffered = true;

            EnableDoubleBufferingForControls(this);

            DisplayArticleNames();
            StartPeriodicTask();
        }

        private int previousItemCount = 0;
        private async void StartPeriodicTask()
        {
            while (true)
            {
                // Lưu số lượng item trước khi gọi DisplayArticleNames
                int itemCountBefore = lvArticleToCreate.Items.Count;

                DisplayArticleNames();

                // Lấy số lượng item sau khi gọi DisplayArticleNames
                int itemCountAfter = lvArticleToCreate.Items.Count;

                // Kiểm tra xem có thêm item mới hay không
                if (itemCountAfter > itemCountBefore)
                {
                    // Hiển thị thông báo chỉ trên frmBpfc
                    MessageBox.Show(new frmBpfc(), "Có Article mới cần kiểm tra!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                await Task.Delay(60000);
            }
        }

        private void EnableDoubleBufferingForControls(Control parentControl)
        {
            foreach (Control control in parentControl.Controls)
            {
                if (control is TextBox || control is Label || control is Panel)
                {
                    control.EnableDoubleBuffering();
                }

                if (control.HasChildren)
                {
                    EnableDoubleBufferingForControls(control);
                }
            }
        }


        private void btnDeleteArt_Click(object sender, EventArgs e)
        {
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            if (lvArticleToCreate.SelectedItems.Count > 0)
            {
                // Lấy tên article từ thuộc tính Text của ListViewItem
                string articleName = lvArticleToCreate.SelectedItems[0].Text;

                dbManager.DeleteArticleToCreate(articleName);
                txtArticle.Clear();
                DisplayArticleNames();
                btnDeleteArt.Visible = false;
            }
        }

        private void DisplayArticleNames()
        { 
            lvArticleToCreate.Items.Clear();

            DatabaseManager dbManager = new DatabaseManager(connectionString);

            List<string> articleNames = dbManager.GetArticleNamesToCreate();

            // Hiển thị danh sách ArticleName lên ListView
            foreach (string articleName in articleNames)
            {
                ListViewItem item = new ListViewItem(articleName);
                lvArticleToCreate.Items.Add(item);
            }
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
                colorBlend.Positions = new float[] { 0.0f, 0.4f, 0.6f, 1.0f }; // Tỉ lệ phân bố màu sắc

                brush.InterpolationColors = colorBlend;

                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
        }

        private void lvArticleToCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvArticleToCreate.SelectedItems.Count > 0)
            {
                string selectedArticle = lvArticleToCreate.SelectedItems[0].Text;

                txtArticle.Text = selectedArticle;

                btnDeleteArt.Visible = true;
            }
            else
            {
                btnDeleteArt.Visible = false; 
            }
        }

        // Xử lý sự kiện đăng xuất
        private void lblLogOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin formLogin = new frmLogin();
                formLogin.Show();

            }
        }
        private void txtArticle_Leave(object sender, EventArgs e)
        { 
            btnCheckArticle_Click(sender, e);
        }

        private void btnCheckArticle_Click(object sender, EventArgs e)
        {
            string article = txtArticle.Text;

            article = article.Replace("-1.5M", "").Replace("-1,5M", "").Replace("-1.5m", "").Replace("-1.5m", "");

            if (!string.IsNullOrEmpty(article))
            {
                DatabaseManager dbManager = new DatabaseManager(connectionString);
                DatabaseManager.ArticleExistenceAction existenceAction = dbManager.CheckArticleExistence(article);

                switch (existenceAction)
                {
                    case DatabaseManager.ArticleExistenceAction.ViewArticleInfo:
                        ArticleData articleData = dbManager.GetArticleData(article);
                        DisplayArticleData(articleData);
                        break;

                    case DatabaseManager.ArticleExistenceAction.HighlightTextBox:
                        txtModel.Focus();
                        dbManager.HighlightTextBoxForShortDuration(txtModel);
                        break;

                    case DatabaseManager.ArticleExistenceAction.None:
                        ClearTextBoxes();
                        break;

                    default:
                        break;
                }
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Focus();
            int createdByUserId = GetCurrentUserId();
            DatabaseManager dbManager = new DatabaseManager(connectionString);

            if (createdByUserId == -1)
            {
                MessageBox.Show("ID người dùng chưa được thiết lập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string article = txtArticle.Text;

            if (string.IsNullOrEmpty(article))
            {
                MessageBox.Show("Vui lòng nhập Article!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtArticle.Focus();
                dbManager.HighlightTextBoxForShortDuration(txtArticle);
                return;
            }

            if (dbManager.ArticleExists(article))
            {
                ArticleData data = GetArticleDataFromTextBoxes();

                ArticleData currentData = dbManager.GetArticleData(article);

                if (IsDataChanged(currentData, data))
                {
                    string username = lblUserCE.Text;

                    string logMessage = $"Article '{data.ArticleName}' đã được chỉnh sửa thành công";

                    dbManager.LogCEActivity(username, data.ArticleName, "Update", "CE");

                    AppendLog(logMessage);

                    dbManager.UpdateArticleData(article, data, createdByUserId);

                    if (!checkboxMultiArticles.Checked)
                    {
                        ClearTextBoxes();
                        txtArticle.Clear();
                    }

                    if (lvArticleToCreate.Items.Cast<ListViewItem>().Any(item => String.Equals(item.Text, article, StringComparison.OrdinalIgnoreCase)))
                    {
                        // Nếu có item giống với article, thực hiện xóa
                        dbManager.DeleteArticleToCreate(article);
                        DisplayArticleNames();
                    }

                    MessageBox.Show("Dữ liệu đã được cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DialogResult result = MessageBox.Show($"Không có sự thay đổi trong dữ liệu của Article {article}.\nĐóng chỉnh sửa dữ liệu?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        ClearTextBoxes();
                        txtArticle.Clear();
                    }
                }
            }
            else
            {
                ArticleData data = GetArticleDataFromTextBoxes();
                dbManager.SaveArticleData(data, createdByUserId);

                string username = lblUserCE.Text;

                string logMessage = $"Article '{data.ArticleName}' đã được lưu thành công";

                dbManager.LogCEActivity(username, data.ArticleName, "Create", "CE");

                AppendLog(logMessage);

                if (!checkboxMultiArticles.Checked)
                {
                    txtArticle.Clear();
                    ClearTextBoxes();
                }

                if (lvArticleToCreate.Items.Cast<ListViewItem>().Any(item => String.Equals(item.Text, article, StringComparison.OrdinalIgnoreCase)))
                {
                    // Nếu có item giống với article, thực hiện xóa
                    dbManager.DeleteArticleToCreate(article);
                    DisplayArticleNames();
                }

                MessageBox.Show("Dữ liệu đã được lưu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // Kiểm tra xem dữ liệu có thay đổi hay không
        private bool IsDataChanged(ArticleData currentData, ArticleData newData)
        {
            if (currentData == null && newData == null)
            {
                return false;
            }
            else if (currentData == null || newData == null)
            {
                return true;
            }

            bool isDataChanged =
                !string.Equals(currentData.ArticleName, newData.ArticleName) ||
                !string.Equals(currentData.Model, newData.Model) ||
                currentData.Temp1Upper != newData.Temp1Upper ||
                !string.Equals(currentData.Time1Upper, newData.Time1Upper) ||
                !string.Equals(currentData.Chemical1Upper, newData.Chemical1Upper) ||
                currentData.Temp2Upper != newData.Temp2Upper ||
                !string.Equals(currentData.Time2Upper, newData.Time2Upper) ||
                !string.Equals(currentData.Chemical2Upper, newData.Chemical2Upper) ||
                currentData.Temp3Upper != newData.Temp3Upper ||
                !string.Equals(currentData.Time3Upper, newData.Time3Upper) ||
                !string.Equals(currentData.Chemical3Upper, newData.Chemical3Upper) ||
                currentData.Temp1Outsole != newData.Temp1Outsole ||
                !string.Equals(currentData.Time1Outsole, newData.Time1Outsole) ||
                !string.Equals(currentData.Chemical1Outsole, newData.Chemical1Outsole) ||
                currentData.Temp2Outsole != newData.Temp2Outsole ||
                !string.Equals(currentData.Time2Outsole, newData.Time2Outsole) ||
                !string.Equals(currentData.Chemical2Outsole, newData.Chemical2Outsole) ||
                currentData.Temp3Outsole != newData.Temp3Outsole ||
                !string.Equals(currentData.Time3Outsole, newData.Time3Outsole) ||
                !string.Equals(currentData.Chemical3Outsole, newData.Chemical3Outsole);

            return isDataChanged;
        }

        private void CheckAndUpdateTimeFields(string article, ArticleData articleData)
        {
            if (article.Contains("-1.5M") || article.Contains("-1,5M"))
            {
                // Nếu article chứa chuỗi "-1.5M" hoặc "-1,5M"
                if (articleData.Time1Upper != null && !string.IsNullOrEmpty(articleData.Time1Upper))
                {
                    // Nếu giá trị của Time1Upper không null, thì đặt giá trị cho txtStdTime1Upper
                    txtTime1Upper.Text = "1:15-1:45";
                }

                if (articleData.Time1Outsole != null && !string.IsNullOrEmpty(articleData.Time1Outsole))
                {
                    // Nếu giá trị của Time2Outsole không null, thì đặt giá trị cho txtStdTime2Outsole
                    txtTime1Outsole.Text = "1:15-1:45";
                }
            }
            else
            {
                // Nếu article không chứa chuỗi "-1.5M" hoặc "-1,5M"
                // Hiển thị các giá trị như bình thường
                txtTime1Upper.Text = articleData.Time1Upper;
                txtTime1Outsole.Text = articleData.Time1Outsole;
            }
        }

        // Hiển thị thông tin Article lên giao diện
        private void DisplayArticleData(ArticleData articleData)
        {
            lblCreatedAt.Text = $"Thời gian tạo: {articleData.CreatedAt.ToString()}";
            lblCreatedBy.Text = $"Người tạo: {articleData.CreatedBy}";
            txtModel.Text = articleData.Model;

            CheckAndUpdateTimeFields(txtArticle.Text, articleData);

            // Hiển thị thông tin lên các TextBox Upper
            txtTemp1Upper.Text = articleData.Temp1Upper.HasValue ? articleData.Temp1Upper.Value.ToString()  + " ±5" : "";
            txtChemical1Upper.Text = articleData.Chemical1Upper;
            txtTemp2Upper.Text = articleData.Temp2Upper.HasValue ? articleData.Temp2Upper.Value.ToString() + " ±5" : "";
            txtTime2Upper.Text = articleData.Time2Upper;
            txtChemical2Upper.Text = articleData.Chemical2Upper;
            txtTemp3Upper.Text = articleData.Temp3Upper.HasValue ? articleData.Temp3Upper.Value.ToString() + " ±5" : "";
            txtTime3Upper.Text = articleData.Time3Upper;
            txtChemical3Upper.Text = articleData.Chemical3Upper;

            // Hiển thị thông tin lên các TextBox Outsole
            txtTemp1Outsole.Text = articleData.Temp1Outsole.HasValue ? articleData.Temp1Outsole.Value.ToString() + " ±5" : "";
            txtChemical1Outsole.Text = articleData.Chemical1Outsole;
            txtTemp2Outsole.Text = articleData.Temp2Outsole.HasValue ? articleData.Temp2Outsole.Value.ToString() + " ±5" : "";
            txtTime2Outsole.Text = articleData.Time2Outsole;
            txtChemical2Outsole.Text = articleData.Chemical2Outsole;
            txtTemp3Outsole.Text = articleData.Temp3Outsole.HasValue ? articleData.Temp3Outsole.Value.ToString() + " ±5" : "";
            txtTime3Outsole.Text = articleData.Time3Outsole;
            txtChemical3Outsole.Text = articleData.Chemical3Outsole;
        }

        // Lấy dữ liệu từ các TextBox vào đối tượng ArticleData
        private ArticleData GetArticleDataFromTextBoxes()
        {
            return new ArticleData
            {
                Model = txtModel.Text,
                ArticleName = txtArticle.Text,
                Temp1Upper = ParseTemperatureTextBoxValue(txtTemp1Upper.Text),
                Time1Upper = txtTime1Upper.Text,
                Chemical1Upper = txtChemical1Upper.Text,
                Temp2Upper = ParseTemperatureTextBoxValue(txtTemp2Upper.Text),
                Time2Upper = txtTime2Upper.Text,
                Chemical2Upper = txtChemical2Upper.Text,
                Temp3Upper = ParseTemperatureTextBoxValue(txtTemp3Upper.Text),
                Time3Upper = txtTime3Upper.Text,
                Chemical3Upper = txtChemical3Upper.Text,
                Temp1Outsole = ParseTemperatureTextBoxValue(txtTemp1Outsole.Text),
                Time1Outsole = txtTime1Outsole.Text,
                Chemical1Outsole = txtChemical1Outsole.Text,
                Temp2Outsole = ParseTemperatureTextBoxValue(txtTemp2Outsole.Text),
                Time2Outsole = txtTime2Outsole.Text,
                Chemical2Outsole = txtChemical2Outsole.Text,
                Temp3Outsole = ParseTemperatureTextBoxValue(txtTemp3Outsole.Text),
                Time3Outsole = txtTime3Outsole.Text,
                Chemical3Outsole = txtChemical3Outsole.Text,
            };
        }

        // Ghi log và hiển thị lên giao diện
        private void AppendLog(string logMessage)
        {
            string logEntry = $"{logMessage}";

            // Thêm một dòng trống trước khi ghi log mới
            txtLog.AppendText(Environment.NewLine);

            // Tiếp theo, thêm log mới
            txtLog.AppendText(logEntry + Environment.NewLine);

            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
            lastLogTime = DateTime.Now;
        }


        private float? ParseTemperatureTextBoxValue(string textBoxText)
        {
            // Tách giá trị nhiệt độ từ chuỗi (loại bỏ " ±5" và khoảng trắng nếu có)
            string[] parts = textBoxText.Split(new string[] { "±5" }, StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length > 0)
            {
                string temperatureText = parts[0].Replace(" ", "").Trim();

                // Thử chuyển đổi giá trị thành số thực
                if (float.TryParse(temperatureText, out float temperature))
                {
                    return temperature;
                }
            }

            return null;
        }

        // Lấy ID người dùng hiện tại
        private int GetCurrentUserId()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlQuery = "SELECT UserId FROM Users WHERE Username = @Username";
                using (SqlCommand cmd = new SqlCommand(sqlQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@Username", GetCurrentUsername());
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return (int)result;
                    }
                }
            }

            return -1;
        }

        private string GetCurrentUsername()
        {
            string username = lblUserCE.Text;
            return username;
        }

        // Xóa nội dung các TextBox
        private void ClearTextBoxes()
        {
            txtModel.Clear();
            txtTemp1Upper.Clear();
            txtTime1Upper.Clear();
            txtTime1Outsole.Clear();
            txtTemp1Outsole.Clear();
            txtTemp2Upper.Clear();
            txtTemp2Outsole.Clear();
            txtTemp3Upper.Clear();
            txtTemp3Outsole.Clear();
            txtTime2Upper.Clear();
            txtTime2Outsole.Clear();
            txtTime3Upper.Clear();
            txtTime3Outsole.Clear();
            txtChemical1Upper.Clear();
            txtChemical1Outsole.Clear();
            txtChemical2Upper.Clear();
            txtChemical2Outsole.Clear();
            txtChemical3Upper.Clear();
            txtChemical3Outsole.Clear();
            lblCreatedAt.Text = "";
            lblCreatedBy.Text = "";
        }

        // Xóa các dòng log cũ hơn 12 giờ
        private void timerDeleteLog_Tick(object sender, EventArgs e)
        {
            for (int i = txtLog.Lines.Length - 1; i >= 0; i--)
            {
                string logLine = txtLog.Lines[i];
                string[] parts = logLine.Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);

                if (parts.Length >= 2)
                {
                    if (DateTime.TryParseExact(parts[0], "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime logDateTime))
                    {
                        TimeSpan timeElapsed = DateTime.Now - logDateTime;

                        if (timeElapsed.TotalHours >= 12)
                        {
                            RemoveLogLine(i);
                        }
                    }
                }
            }
        }

        // Xóa một dòng log
        private void RemoveLogLine(int lineIndex)
        {
            string[] lines = txtLog.Lines;
            List<string> updatedLines = new List<string>(lines);

            if (lineIndex >= 0 && lineIndex < lines.Length)
            {
                updatedLines.RemoveAt(lineIndex);
                txtLog.Lines = updatedLines.ToArray();
            }
        }

        // Xóa nội dung các TextBox khi thay đổi giá trị của TextBox Article
        private void txtArticle_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = textBox.Text.Length;

            if (!checkboxMultiArticles.Checked)
            {
                ClearTextBoxes();
            }
        }

        private void txtStdTime_Leave(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string input = textBox.Text.Replace(" ", "").Replace("\n", "").Replace("\r\n", "");

            if (string.IsNullOrWhiteSpace(input))
            {
            }
            else
            {
                // Sử dụng biểu thức chính quy để kiểm tra định dạng
                if (System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{1,2}:\d{2}-\d{1,2}:\d{2}$") ||
                    System.Text.RegularExpressions.Regex.IsMatch(input, @"^\d{1,2}:\d{1,2}-\d{1,2}:\d{1,2}$"))
                {
                    // Định dạng hợp lệ, không cần thay đổi gì
                }
                else
                {
                    // Định dạng không hợp lệ, thông báo cho người dùng
                    MessageBox.Show("Định dạng không hợp lệ.\nVui lòng nhập lại theo định dạng mm:ss - mm:ss hoặc m:ss - m:ss.", "Invalid format", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    textBox.Focus();
                }
            }
        }


        public class ArticleData
        {
            public string Model { get; set; }
            public string ArticleName { get; set; }
            public float? Temp1Upper { get; set; }
            public string Time1Upper { get; set; }
            public string Chemical1Upper { get; set; }
            public float? Temp2Upper { get; set; }
            public string Time2Upper { get; set; }
            public string Chemical2Upper { get; set; }
            public float? Temp3Upper { get; set; }
            public string Time3Upper { get; set; }
            public string Chemical3Upper { get; set; }
            public float? Temp1Outsole { get; set; }
            public string Time1Outsole { get; set; }
            public string Chemical1Outsole { get; set; }
            public float? Temp2Outsole { get; set; }
            public string Time2Outsole { get; set; }
            public string Chemical2Outsole { get; set; }
            public float? Temp3Outsole { get; set; }
            public string Time3Outsole { get; set; }
            public string Chemical3Outsole { get; set; }
            public DateTime CreatedAt { get; set; }
            public string CreatedBy { get; set; }

        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn hủy bỏ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Kiểm tra kết quả xác nhận
            if (result == DialogResult.Yes)
            {
                ClearTextBoxes();
                txtArticle.Clear();
            }
        }
        private void txtTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;

                errorToolTip.Show("Chỉ được nhập số.", textBox, 0, -textBox.Height, 2000);
            }

            if ((e.KeyChar == '.') && (textBox.Text.IndexOf('.') > -1))
            {
                e.Handled = true;

                errorToolTip.Show("Chỉ được nhập một dấu thập phân.", textBox, 0, -textBox.Height, 2000);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && !string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text += " ±5";
            }
        }
        private void TextBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null)
            {
                
                string text = textBox.Text.TrimEnd();

                if (text.EndsWith(" ±5"))
                {
                    text = text.Substring(0, text.Length - 3);
                }

                textBox.Text = text;
            }
        }
        public string UserName { get; set; }
        private void btnHome_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmHome formHome = new frmHome();
            formHome.Show();
        }
        private void frmBpfc_Load(object sender, EventArgs e)
        {
            lblUserCE.Text = Globals.Username;
        }

        private void lblLogOut_MouseEnter(object sender, EventArgs e)
        {
            lblLogOut.ForeColor = System.Drawing.Color.NavajoWhite;
        }

        private void lblLogOut_MouseLeave(object sender, EventArgs e)
        {
            lblLogOut.ForeColor = System.Drawing.Color.DarkOrange;
        }

        private void frmBpfc_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = textBox.Text.ToUpper();
            textBox.SelectionStart = textBox.Text.Length;
        }
    }
}
