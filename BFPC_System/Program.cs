using BPFC_System;
using System;
using System.Windows.Forms;
using System.Configuration;

namespace BFPC_System
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["strCon"].ConnectionString;

            InitializeAdminAccount(connectionString);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form formToOpen = new frmLogin();

            Application.Run(formToOpen);
        }

        private static void InitializeAdminAccount(string connectionString)
        {
            using (AdminInitializer adminInitializer = new AdminInitializer(connectionString))
            {
                adminInitializer.InitializeAdminAccount();
            }
        }
    }
}
