using BPFC_System;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using SystemWinForms = System.Windows.Forms;

namespace BFPC_System
{
    public partial class BPFCPlugin : UserControl
    {
        private string connectionString;
        private frmHome homeForm;

        public BPFCPlugin(frmHome homeForm)
        {
            this.homeForm = homeForm;
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;
        }

        private void BPFCPlugin_Load(object sender, EventArgs e) 
        {

            DatabaseManager dbManager = new DatabaseManager(connectionString);

            if (!string.IsNullOrEmpty(Globals.Username))
            {
                string department = dbManager.GetDepartmentFromDatabase(Globals.Username);

                if (IsUserInMEDepartment(department))
                {
                    btnAdmin.Visible = true;
                }
                else
                {
                    btnAdmin.Visible = false;
                }
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            frmReport report = SystemWinForms.Application.OpenForms.OfType<frmReport>().FirstOrDefault();

            if (report != null)
            {
                report.Close();
            }

            homeForm.Hide();

            frmAdmin formAdmin = new frmAdmin();
            formAdmin.Show();
        }

        private void btnCe_Click(object sender, EventArgs e)
        {
            homeForm.Hide();
            frmBpfc formBpfc = new frmBpfc();
            formBpfc.Show();
        }

        private void btnQip_Click(object sender, EventArgs e)
        {
            using (frmSelectPlant selectPlantForm = new frmSelectPlant())
            {
                selectPlantForm.StartPosition = FormStartPosition.CenterScreen;

                DialogResult result = selectPlantForm.ShowDialog(this);

                if (selectPlantForm.PlantFormOpened)
                {
                    homeForm.Hide();
                }
            }
        }

        private void btnWh_Click(object sender, EventArgs e)
        {
            homeForm.Hide();
            frmWarehouse formWarehouse = new frmWarehouse();
            formWarehouse.Show();
        }

        private void btnMe_Click(object sender, EventArgs e)
        {
            SystemWinForms.Form frmReport = SystemWinForms.Application.OpenForms.OfType<frmReport>().FirstOrDefault();

            if (frmReport != null)
            {
                if (frmReport.Visible)
                {
                    frmReport.BringToFront();
                }
                else
                {
                    frmReport.Show();
                }
            }
            else
            {
                frmReport = new frmReport();
                frmReport.Show();
            }
        }
        private bool IsUserInMEDepartment(string department)
        {
            return string.Equals(department, "ME", StringComparison.OrdinalIgnoreCase);
        }

    }
}