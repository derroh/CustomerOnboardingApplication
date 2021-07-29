using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerOnboardingApplication
{
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public static string LoggedInUser = "";
        public Login()
        {
            InitializeComponent();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (dxValidationProvider1.Validate().Equals(true))
            {
                UserLogin();
            }
        }

        private void textEdit2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                UserLogin();
            }
        }
        private void UserLogin()
        {
            //check if all fields have been filled as defined
            if (dxValidationProvider1.Validate().Equals(true))
            {
                string Username = textEdit1.Text.Trim();
                string Password = textEdit2.Text;// Utilities.EnCryptDecrypt.Encrypt(txt_password.Text.Trim(), true);

                AuthenticateUser(Username, Password);
            }
        }
        private void AuthenticateUser(string Username, string Password)
        {

            if (SaccoBook.EF.SystemUserQueries.CheckUserLogin(Username, Password))
            {
                LoggedInUser = Username;


                this.Hide();
                SplashScreenManager.ShowForm(this, typeof(SaccoBook.AppWaitForm), true, true, false);
                SplashScreenManager.Default.SetWaitFormCaption("Please wait");
                SplashScreenManager.Default.SetWaitFormDescription("Loading modules...");

                Dashboard s = new Dashboard();
                s.Show();
                SplashScreenManager.CloseForm();
            }
            else
            {
                XtraMessageBox.Show("No account with the credentials provided was found. ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}