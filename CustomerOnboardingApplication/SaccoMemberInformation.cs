using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using DevExpress.XtraSplashScreen;
using System.IO;
using DevExpress.XtraEditors;

namespace SaccoBook.Modules.SaccoMembers
{
    using Utilities;
    public partial class SaccoMemberInformation : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        static string MembershipNumber = null;
        static string PathToOldPic = null;

        public SaccoMemberInformation()
        {
            InitializeComponent();
        }
        public SaccoMemberInformation(string _MembershipNumber)
        {
            InitializeComponent();
            MembershipNumber = _MembershipNumber;
            GetMemberinformation(MembershipNumber);
            //EnableDisableForm(false);
            AppResources.DevexpressFunctions.EnableDisableForm(layoutControl1, true);
        }

        /**
        * Function returns members information
        */
        private void GetMemberinformation(string MembershipNumber)
        {
            SplashScreenManager.ShowForm(this, typeof(AppWaitForm), true, true, false);
            SplashScreenManager.Default.SetWaitFormCaption("Please wait");
            SplashScreenManager.Default.SetWaitFormDescription("Loading...");

            string GetMemberInfoJSON = EF.MemberQueries.GetMemberInfo(MembershipNumber);
            dynamic jsonGetMemberInfo = JObject.Parse(GetMemberInfoJSON);

            _MembershipNumber.Text = MembershipNumber;
            _Name.Text = jsonGetMemberInfo.Name;
            _FirstName.Text = jsonGetMemberInfo.FirstName;
            _MiddleName.Text = jsonGetMemberInfo.MiddleName;
            _LastName.Text = jsonGetMemberInfo.LastName;
            _DateOfBirth.Text = jsonGetMemberInfo.DateOfBirth;
            _Gender.Text = jsonGetMemberInfo.Gender;
            _Nationality.Text = jsonGetMemberInfo.Nationality;
            _NationalIdNumber.Text = jsonGetMemberInfo.NationalIdNumber;
            _TaxPIN.Text = jsonGetMemberInfo.TaxPIN;
            _DateJoined.Text = jsonGetMemberInfo.DateJoined;
            _MembershipStatus.Text = jsonGetMemberInfo.MembershipStatus;
            _PhoneNumber.Text = jsonGetMemberInfo.PhoneNumber;
            _AlternativeNumber.Text = jsonGetMemberInfo.AlternativeNumber;
            _Email.Text = jsonGetMemberInfo.Email;
            _Address.Text = jsonGetMemberInfo.Address;
            _SourceOfIncome.Text = jsonGetMemberInfo.SourceOfIncome;
            _Employer.Text = jsonGetMemberInfo.Employer;
            _JobPosition.Text = jsonGetMemberInfo.JobPosition;
            _PayrollNumber.Text = jsonGetMemberInfo.PayrollNumber;
            _EmployerAddress.Text = jsonGetMemberInfo.EmployerAddress;
            _EmployerTelephoneNumber.Text = jsonGetMemberInfo.EmployerTelephoneNumber;
            _GrossMonthlyIncome.Text = jsonGetMemberInfo.GrossMonthlyIncome;

            _Photo.EditValue = null;

            byte[] img = jsonGetMemberInfo.Photo;

            if (img == null)
                _Photo.Image = null;
            else
            {
                MemoryStream mstream = new MemoryStream(img);
                _Photo.Image = System.Drawing.Image.FromStream(mstream);
            }

            SplashScreenManager.CloseForm();         
        }

        private void btn_viewkins_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btn_savingsaccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btn_viewbankaccounts_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void btn_addbankaccount_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btn_addkin_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btn_createsavingsaccount_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void barbtn_savings_ItemClick(object sender, ItemClickEventArgs e)
        {
          
        }

        private void btn_previous_ItemClick(object sender, ItemClickEventArgs e)
        {
            string CurrentMembershipNumber = _MembershipNumber.Text;

            if(CurrentMembershipNumber != "")
            {
                string PreviousMembershipNumber = EF.MemberQueries.GetPreviousMember(CurrentMembershipNumber);

                if (PreviousMembershipNumber != null)
                {
                    btn_next.Enabled = true;
                    MembershipNumber = PreviousMembershipNumber;
                    GetMemberinformation(PreviousMembershipNumber);
                }
                else
                {
                    btn_previous.Enabled = false;
                }
            }         
        }

        private void btn_next_ItemClick(object sender, ItemClickEventArgs e)
        {
            string CurrentMembershipNumber = _MembershipNumber.Text;

            if (CurrentMembershipNumber != "")
            {
                string sql = "SELECT TOP 1 * FROM [saccobook].[members] WHERE MembershipNumber > '" + CurrentMembershipNumber + "' ORDER BY MembershipNumber Asc";
                string NextMembershipNumber = EF.MemberQueries.GetNextMember(CurrentMembershipNumber);

                if (NextMembershipNumber != null)
                {
                    btn_previous.Enabled = true;
                    MembershipNumber = NextMembershipNumber;
                    GetMemberinformation(NextMembershipNumber);
                }
                else
                {
                    btn_next.Enabled = false;
                }
            }           
        }
        private void update()
        {
            byte[] Photo = null;

            if (_Photo.EditValue != null)
            {
                MemoryStream stream = new MemoryStream();
                Photo = ImageToByteArray(_Photo.Image);
            }

            string GrossMonthlyIncome = _GrossMonthlyIncome.Text.Replace(",", "");

            if (EF.MemberQueries.UpdateMember(_MembershipNumber.Text, _Name.Text, _FirstName.Text, _MiddleName.Text, _LastName.Text, _PhoneNumber.Text, _AlternativeNumber.Text, _Email.Text, Convert.ToDateTime(_DateOfBirth.Text), _Gender.Text, _Nationality.Text, _NationalIdNumber.Text, _TaxPIN.Text, _Address.Text, Photo, _Password.Text,
                _SourceOfIncome.Text, _Employer.Text, _JobPosition.Text, _PayrollNumber.Text, _EmployerAddress.Text, _EmployerTelephoneNumber.Text, Convert.ToDouble(GrossMonthlyIncome), Convert.ToDateTime(_DateJoined.Text), _MembershipStatus.Text, CustomerOnboardingApplication.Login.LoggedInUser, DateTime.Now.ToString()))
            {
                alertControl1.Show(this, "Success!", "Information has been successfully saved");
                //XtraMessageBox.Show("Information has been successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (dxValidationProviderSaccoMember.Validate().Equals(true))
            {
                update();
            }
        }

        private void _FirstName_TextChanged(object sender, EventArgs e)
        {
            if (_MiddleName.Text != "")
            {
                _Name.Text = _FirstName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _MiddleName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _LastName.Text.Trim().ToTitleCase(TitleCase.All);
            }
            else
            {
                _Name.Text = _FirstName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _LastName.Text.Trim().ToTitleCase(TitleCase.All);
            }
        }

        private void _MiddleName_TextChanged(object sender, EventArgs e)
        {
            _Name.Text = _FirstName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _MiddleName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _LastName.Text.Trim().ToTitleCase(TitleCase.All);
        }

        private void _LastName_TextChanged(object sender, EventArgs e)
        {
            if (_MiddleName.Text != "")
            {
                _Name.Text = _FirstName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _MiddleName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _LastName.Text.Trim().ToTitleCase(TitleCase.All);
            }
            else
            {
                _Name.Text = _FirstName.Text.Trim().ToTitleCase(TitleCase.All) + " " + _LastName.Text.Trim().ToTitleCase(TitleCase.All);
            }
        }

        private void btn_edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            AppResources.DevexpressFunctions.EnableDisableForm(layoutControl1, false);
        }

        private void btn_beneficiary_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void btn_viewbeneficiaries_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        public byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}