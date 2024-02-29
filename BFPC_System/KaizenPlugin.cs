using BPFC_System;
using System;
using System.Configuration;
using System.Windows.Forms;


namespace BFPC_System
{
    public partial class KaizenPlugin : UserControl
    {
        private string connectionString;

        public KaizenPlugin()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

        }
        private bool IsUserInMEDepartment(string department)
        {
            return string.Equals(department, "ME", StringComparison.OrdinalIgnoreCase);
        }
        private void Kaizenlugin_Load(object sender, EventArgs e) 
        {

            DatabaseManager dbManager = new DatabaseManager(connectionString);

            this.BeginInvoke(new Action(() =>
            {
                if (!string.IsNullOrEmpty(Globals.Username))
                {
                    string department = dbManager.GetDepartmentFromDatabase(Globals.Username);

                    if (IsUserInMEDepartment(department))
                    {
                        btnMe.Visible = true;
                    }
                    else
                    {
                        btnMe.Visible = false;
                    }
                }
            }));
        }
    }
}
