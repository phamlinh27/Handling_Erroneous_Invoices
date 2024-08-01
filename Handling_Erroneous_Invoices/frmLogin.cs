using API3.SDK.Interface;
using API3.SDK;
using System;
using System.Windows.Forms;
using API3.SDK.Model.SDKResult;
using System.Configuration;

namespace Handling_Erroneous_Invoices
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            txtTaxCode.Text = Program.TaxCode;
            txtUserName.Text = Program.UserName;
            txtPassWord.Text = Program.PassWord;
            cbSave.Checked = Program.IS_Code;

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IAuthen authen = MeInvoiceFactory.CreateAuthenClass();
            GetTokenOperationResult oResult = authen.GetToken(Program.AppID, txtTaxCode.Text, txtUserName.Text, txtPassWord.Text);

            if(oResult.Success == true)
            {
                Program.TOKEN = oResult.Token;
                execute_after_login_success();
                frmMain frmMain = new frmMain(this);
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Thông tin đăng nhập không chính xác!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void execute_after_login_success()
        {
            if (cbSave.Checked)
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                config.AppSettings.Settings.Remove("TOKEN");
                config.AppSettings.Settings.Add("TOKEN", Program.TOKEN);

                if (txtTaxCode.Text.Trim() != Program.TaxCode)
                {
                    config.AppSettings.Settings.Remove("TaxCode");
                    config.AppSettings.Settings.Add("TaxCode", txtTaxCode.Text);
                }
                if (txtUserName.Text.Trim() != Program.UserName)
                {
                    config.AppSettings.Settings.Remove("UserName");
                    config.AppSettings.Settings.Add("UserName", txtUserName.Text);
                }
                if (txtPassWord.Text.Trim() != Program.PassWord)
                {
                    config.AppSettings.Settings.Remove("PassWord");
                    config.AppSettings.Settings.Add("PassWord", txtPassWord.Text);
                }
                if (cbSave.Checked != Program.IS_Save)
                {
                    config.AppSettings.Settings.Remove("IS_Save");
                    config.AppSettings.Settings.Add("IS_Save", cbSave.Checked.ToString());
                }
                config.Save(ConfigurationSaveMode.Modified);
            }
        }

        private void frmLogin_Shown(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Program.TOKEN))
            {
                ICompany company = MeInvoiceFactory.CreateCompanyClass(Program.TaxCode,Program.TOKEN);
                if (company.GetCompanyInfo().Success)
                {
                    frmMain frmMain = new frmMain(this);
                    frmMain.Closed += (s, args) => this.Close();
                    frmMain.Show();
                    this.Hide();
                }
                else
                {
                    Program.TOKEN = "";
                }
            }
        }
    }
}
