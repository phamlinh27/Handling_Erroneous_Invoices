using API3.SDK;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace Handling_Erroneous_Invoices
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadConfig();
            Application.Run(new frmLogin());
        }

        public static string AppID { get; set; }
        public static string TaxCode { get; set; }
        public static string UserName { get; set; }
        public static string PassWord { get; set; }
        public static bool IS_Save { get; set; }
        public static bool IS_Code { get; set; } = false;
        public static string TOKEN { get; set; }

        static void LoadConfig()
        {
            AppID = ConfigurationSettings.AppSettings["AppID"];
            TaxCode = ConfigurationSettings.AppSettings["TaxCode"];
            UserName = ConfigurationSettings.AppSettings["UserName"];
            PassWord = ConfigurationSettings.AppSettings["PassWord"];
            TOKEN = ConfigurationSettings.AppSettings["TOKEN"];
            IS_Save = bool.Parse(ConfigurationSettings.AppSettings["IS_Save"]);
            IS_Code = bool.Parse(ConfigurationSettings.AppSettings["IS_Code"]);

            MeInvoiceFactory.MEAPIV3URL = ConfigurationSettings.AppSettings["URL_BASE"];
            MeInvoiceFactory.MECODEAPIV3URL = ConfigurationSettings.AppSettings["URL_BASE"] + "/code";
        }
    }
}
