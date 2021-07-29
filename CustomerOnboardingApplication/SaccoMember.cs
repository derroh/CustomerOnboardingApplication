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
using DevExpress.XtraEditors;
using System.IO;
using Newtonsoft.Json.Linq;

namespace SaccoBook.Modules.SaccoMembers
{
    using DevExpress.XtraSplashScreen;
    using SaccoBook.AppResources;
    using System.Drawing.Imaging;
    using System.Globalization;
    using Utilities;
    public partial class SaccoMember : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        bool Edit = false;
        static string PathToOldPic = null;
        string _NumberSeriesCode = XMLFormatter.GetContent("MembersNumberSeriesCode");
        bool IsDocumentCreated = false;

        public SaccoMember()
        {
            InitializeComponent();
           // LoadComboEdit(_Nationality, EF.SystemSettingsQueries.GetCountriesList());
            GetDocumentNumber(_NumberSeriesCode);
            //AppResources.DevexpressFunctions.SetDateFormat(_DateOfBirth);
            //AppResources.DevexpressFunctions.SetDateFormat(_DateJoined);
            //AppResources.DevexpressFunctions.SetDateFormat(_DateOfBirth);
        }

        public SaccoMember(string MembershipNumber, bool _Edit)
        {
            InitializeComponent();
          //  LoadComboEdit(_Nationality, EF.SystemSettingsQueries.GetCountriesList());
            Edit = _Edit;
            LoadMemberInformation(MembershipNumber);
        }

        private void LoadMemberInformation(string MembershipNumber)
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
            _PhoneNumber.Text =jsonGetMemberInfo.PhoneNumber;
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

            string Photo = Path.GetDirectoryName(Application.ExecutablePath) + @"\Photos\" + jsonGetMemberInfo.Photo + ".jpg";

            PathToOldPic = Photo;

            try
            {
                //check if photo exists
                if (File.Exists(Photo))
                {
                    Bitmap myPic = (Bitmap)Image.FromFile(Photo);

                    _Photo.EditValue = myPic;
                }
                //end photo
            }
            catch (FileNotFoundException ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }

            SplashScreenManager.CloseForm();
        }

        private void GetDocumentNumber(string DocumentNumberSeriesCode)
        {
                      
        }

        private void LoadComboEdit(ComboBoxEdit combo, string[] list)
        {
            combo.Properties.Items.Clear();

            foreach (var item in list)
            {
                combo.Properties.Items.Add(item);
            }
        }            
       
        private void btn_save_ItemClick(object sender, ItemClickEventArgs e)
        {          
            if (dxValidationProviderSaccoMember.Validate().Equals(true))
            {
                if (Edit)
                {
                    update();
                }
                else
                {
                    if (!IsDocumentCreated)
                    {
                        save();
                    }
                    else
                    {
                        update();
                    }                    
                }
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

        private void btn_attachment_ItemClick(object sender, ItemClickEventArgs e)
        {
            
        }

        private void btn_viewattachments_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }
        private void save()
        {            
            byte[] Photo = null;

            if (_Photo.EditValue != null)
            {
                MemoryStream stream = new MemoryStream();
                Photo = ImageToByteArray(_Photo.Image);
            }
            string GrossMonthlyIncome = _GrossMonthlyIncome.Text.Replace(",", "");

            if (EF.MemberQueries.CreateMember(_MembershipNumber.Text, _Name.Text, _FirstName.Text, _MiddleName.Text, _LastName.Text, _PhoneNumber.Text, _AlternativeNumber.Text, _Email.Text, Convert.ToDateTime(_DateOfBirth.Text), _Gender.Text, _Nationality.Text, _NationalIdNumber.Text, _TaxPIN.Text, _Address.Text, Photo, _Password.Text,
                _SourceOfIncome.Text, _Employer.Text, _JobPosition.Text, _PayrollNumber.Text, _EmployerAddress.Text, _EmployerTelephoneNumber.Text, Convert.ToDouble(GrossMonthlyIncome), Convert.ToDateTime(_DateJoined.Text), _MembershipStatus.Text, CustomerOnboardingApplication.Login.LoggedInUser, DateTime.Now.ToString()))
            {
                //Update number series
              //  EF.NumberSeriesQueries.UpdateLastUsedNumberSeries(_NumberSeriesCode, _MembershipNumber.Text);
                //Send notification
              //  EF.MemberQueries.SendMemberRegistrationNotification(_PhoneNumber.Text, _Name.Text, _NationalIdNumber.Text, DateTime.Now.ToString("dd/MM/yyy"), DateTime.Now.TimeOfDay.ToString(), _Email.Text);

                IsDocumentCreated = true;

                XtraMessageBox.Show("Information has been successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void update()
        {    
            //Proccess Image
            AppResources.AppFunctions.CreateAppFolders();

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
                XtraMessageBox.Show("Information has been successfully saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public byte[] ImageToByteArray(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
    }
}