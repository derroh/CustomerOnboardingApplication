using DevExpress.XtraEditors;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaccoBook.EF
{
    class MemberQueries
    {
        /**
        * Function returns members information
        * @param MembershipNumber | The member's membership number 

        * @return string | returns json string of member's information
        */
        public static string GetMemberInfo(string MembershipNumber)
        {
            string MemberInfo = null;
            try
            {
                using (var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.member member = db.members.Where(x => x.MembershipNumber == MembershipNumber).SingleOrDefault();

                    if (member != null)                    
                    {
                        var _Member = new Member
                        {
                            MembershipNumber = member.MembershipNumber,
                            Name = member.Name,
                            FirstName = member.FirstName,
                            MiddleName = member.MiddleName,
                            LastName = member.LastName,
                            PhoneNumber = member.PhoneNumber,
                            AlternativeNumber = member.AlternativeNumber,
                            Email = member.Email,
                            DateOfBirth = member.DateOfBirth,
                            Gender = member.Gender,
                            Nationality = member.Nationality,
                            NationalIdNumber = member.NationalIdNumber,
                            TaxPIN = member.TaxPIN,
                            Address = member.Address,
                            Photo = member.Photo,
                            Password = member.Password,
                            SourceOfIncome = member.SourceOfIncome,
                            Employer = member.Employer,
                            JobPosition = member.JobPosition,
                            PayrollNumber = member.PayrollNumber,
                            EmployerAddress = member.EmployerAddress,
                            EmployerTelephoneNumber = member.EmployerTelephoneNumber,
                            GrossMonthlyIncome = member.GrossMonthlyIncome,
                            DateJoined = member.DateJoined,
                            MembershipStatus = member.MembershipStatus,
                            LastModifiedBy = member.LastModifiedBy,
                            LastModifiedAt = member.LastModifiedAt
                        };

                        MemberInfo = JsonConvert.SerializeObject(_Member);
                    }
                }
            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Error);
            }
            return MemberInfo;
        }

        /**
        * Function creates new Member
        * @param MembershipNumber | The member's membership number
        * @param Name | The member's full name
        * @param FirstName | The member's first name
        * @param MiddleName | The member's middle name
        * @param LastName | The member's last name
        * @param PhoneNumber | The member's phone number
        * @param AlternativeNumber | The member's alternative phone number
        * @param Email | The member's email address
        * @param DateOfBirth | The member's date of birth
        * @param Gender | The member's gender
        * @param Nationality | The member's nationality
        * @param NationalIdNumber | The member's national id number
        * @param TaxPIN | The member's tax pin (KRA/URA)
        * @param Address | The member's address
        * @param Photo | The member's photo name
        * @param Password | The member's portal password
        * @param SourceOfIncome | The member's primary source of income
        * @param Employer | The member's current employer
        * @param JobPosition | The member's job postion
        * @param PayrollNumber | The member's payroll number
        * @param EmployerAddress | The member's employer's address
        * @param EmployerTelephoneNumber | The member's employer's phone number
        * @param GrossMonthlyIncome | The member's gross monthly income
        * @param DateJoined | The date member joined the sacco
        * @param MembershipStatus | The member's membership status
        * @param LastModifiedBy | The user that last modified the record
        * @param LastModifiedAt | The time the record was last modified

        * @return bool | return true if member information is created / return false if not created
        */
        public static bool CreateMember(string MembershipNumber, string Name, string FirstName, string MiddleName, string LastName, string PhoneNumber, string AlternativeNumber, string Email, DateTime DateOfBirth, string Gender, string Nationality, string NationalIdNumber, string TaxPIN, string Address, byte[] Photo, string Password,
        string SourceOfIncome, string Employer, string JobPosition, string PayrollNumber, string EmployerAddress, string EmployerTelephoneNumber, double GrossMonthlyIncome,
        DateTime DateJoined, string MembershipStatus, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;

            try
            {
                using(var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    if (db.members.Any(o => o.NationalIdNumber == NationalIdNumber))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the National ID Number provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (db.members.Any(o => o.TaxPIN == TaxPIN))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Tax PIN provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (db.members.Any(o => o.PhoneNumber == PhoneNumber))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Phone Number provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (db.members.Any(o => o.Email == Email))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Email address provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    var member = new CustomerOnboardingApplication.EF.member()
                    {
                        MembershipNumber = MembershipNumber,
                        Name = Name,
                        FirstName = FirstName,
                        MiddleName = MiddleName,
                        LastName = LastName,
                        PhoneNumber = PhoneNumber,
                        AlternativeNumber = AlternativeNumber,
                        Email = Email,
                        DateOfBirth = DateOfBirth,
                        Gender = Gender,
                        Nationality = Nationality,
                        NationalIdNumber = NationalIdNumber,
                        TaxPIN = TaxPIN,
                        Address = Address,
                        Photo = Photo,
                        Password = Password,
                        SourceOfIncome = SourceOfIncome,
                        Employer = Employer,
                        JobPosition = JobPosition,
                        PayrollNumber = PayrollNumber,
                        EmployerAddress = EmployerAddress,
                        EmployerTelephoneNumber = EmployerTelephoneNumber,
                        GrossMonthlyIncome = GrossMonthlyIncome,
                        DateJoined = DateJoined,
                        MembershipStatus = MembershipStatus,
                        MembershipType = "Individual",
                        LastModifiedBy = LastModifiedBy,
                        LastModifiedAt = LastModifiedAt,
                    };
                    db.members.Add(member);
                    db.SaveChanges();

                    status = true;
                }
            }

            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Error);
            }
            return status;
        }

        /**
        * Function updates new Member
        * @param MembershipNumber | The member's membership number
        * @param Name | The member's full name
        * @param FirstName | The member's first name
        * @param MiddleName | The member's middle name
        * @param LastName | The member's last name
        * @param PhoneNumber | The member's phone number
        * @param AlternativeNumber | The member's alternative phone number
        * @param Email | The member's email address
        * @param DateOfBirth | The member's date of birth
        * @param Gender | The member's gender
        * @param Nationality | The member's nationality
        * @param NationalIdNumber | The member's national id number
        * @param TaxPIN | The member's tax pin (KRA/URA)
        * @param Address | The member's address
        * @param Photo | The member's photo name
        * @param Password | The member's portal password
        * @param SourceOfIncome | The member's primary source of income
        * @param Employer | The member's current employer
        * @param JobPosition | The member's job postion
        * @param PayrollNumber | The member's payroll number
        * @param EmployerAddress | The member's employer's address
        * @param EmployerTelephoneNumber | The member's employer's phone number
        * @param GrossMonthlyIncome | The member's gross monthly income
        * @param DateJoined | The date member joined the sacco
        * @param MembershipStatus | The member's membership status
        * @param LastModifiedBy | The user that last modified the record
        * @param LastModifiedAt | The time the record was last modified

        * @return bool | return true if member information is updated / return false if not updated
        */
        public static bool UpdateMember(string MembershipNumber, string Name, string FirstName, string MiddleName, string LastName, string PhoneNumber, string AlternativeNumber, string Email, DateTime DateOfBirth, string Gender, string Nationality, string NationalIdNumber, string TaxPIN, string Address, byte[] Photo, string Password,
        string SourceOfIncome, string Employer, string JobPosition, string PayrollNumber, string EmployerAddress, string EmployerTelephoneNumber, double GrossMonthlyIncome,
        DateTime DateJoined, string MembershipStatus, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;

            try
            {
                using (var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    if (db.members.Any(o => o.NationalIdNumber == NationalIdNumber))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the National ID Number provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                        return false;
                    }
                    if (db.members.Any(o => o.TaxPIN == TaxPIN))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Tax PIN provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (db.members.Any(o => o.PhoneNumber == PhoneNumber))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Phone Number provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                    if (db.members.Any(o => o.Email == Email))
                    {
                        XtraMessageBox.Show("An Error Occured: Information was not saved.\nA member with the Email address provided already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }

                    CustomerOnboardingApplication.EF.member member = db.members.Where(x => x.MembershipNumber == MembershipNumber).SingleOrDefault();

                    if (member == null)
                    {
                        status = false;
                    }
                    else
                    {
                        member.Name = Name;
                        member.FirstName = FirstName;
                        member.MiddleName = MiddleName;
                        member.LastName = LastName;
                        member.PhoneNumber = PhoneNumber;
                        member.AlternativeNumber = AlternativeNumber;
                        member.Email = Email;
                        member.DateOfBirth = DateOfBirth;
                        member.Gender = Gender;
                        member.Nationality = Nationality;
                        member.NationalIdNumber = NationalIdNumber;
                        member.TaxPIN = TaxPIN;
                        member.Address = Address;
                        member.Photo = Photo;
                        member.Password = Password;
                        member.SourceOfIncome = SourceOfIncome;
                        member.Employer = Employer;
                        member.JobPosition = JobPosition;
                        member.PayrollNumber = PayrollNumber;
                        member.EmployerAddress = EmployerAddress;
                        member.EmployerTelephoneNumber = EmployerTelephoneNumber;
                        member.GrossMonthlyIncome = GrossMonthlyIncome;
                        member.DateJoined = DateJoined;
                        member.MembershipStatus = MembershipStatus;
                        member.MembershipType = "Individual";
                        member.LastModifiedBy = LastModifiedBy;
                        member.LastModifiedAt = LastModifiedAt;
                        db.SaveChanges();
                        status = true;
                    }
                }
            }

            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Error);
            }
            return status;
        }

        /**
        * Function deletes Members 
        * @param MembershipNumber | The member's membership number

        * @return bool | return true if member is deleted / return false if not deleted
        */
        public static bool DeleteMember(string MembershipNumber)
        {
            bool status = false;
            try
            {
                using(var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.member _member = db.members.Where(x => x.MembershipNumber == MembershipNumber).SingleOrDefault();
                    if (_member == null)
                    {
                        status = false;
                    }
                    else
                    {
                        db.members.Remove(_member);
                        db.SaveChanges();
                        status = true;
                    }
                }
            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                 System.Diagnostics.EventLogEntryType.Error);
            }
            return status;
        }             
       
        public static void SendMemberRegistrationNotification(string PhoneNumber, string FullName, string IdNumber, string Date, string Time, string Email)
        {            
                
        }
        /**
        * Function  lists Active members on search control except a specified one
        * 
        * @param _SearchLookUpEdit | SearchLookUpEdit control to be loaded
        * @param MembershipNumber | Specified member to be excluded
        */
        public static void LoadMembers(DevExpress.XtraEditors.SearchLookUpEdit _SearchLookUpEdit, string MembershipNumber)
        {
            string sql = @"select members.MembershipNumber, members.Name
                              from members members
                             where ((members.MembershipStatus = 'Active')
                                   and (members.MembershipNumber <> '"+MembershipNumber+"'))";
            AppResources.AppFunctions.LoadSearchLookUpEdit(_SearchLookUpEdit, sql);
        }
        public static void LoadActiveMembers(DevExpress.XtraEditors.SearchLookUpEdit _SearchLookUpEdit, string MembershipNumber)
        {
            string sql = @" SELECT TOP (1000) [MembershipNumber]
                              ,[Name]
                          FROM [Sacco Book].[saccobook].[members] WHERE [MembershipStatus] ='Active'";
            AppResources.AppFunctions.LoadSearchLookUpEdit(_SearchLookUpEdit, sql);
        }
        /*
        * Function returns SQL string for fetching members of a specified status
        * 
        * @param status | The member's membership status
        * 
        * @return string | returns SQL string for fetching members of the specified status
        */
        public static string LoadMembersList(string status)
        {
            string sql = @"select MembershipNumber,Name, PhoneNumber, Email, Gender,PayrollNumber,DateJoined,MembershipStatus
                              from [saccobook].[members]
                             where (MembershipStatus = '" + status + "')";

            return sql;
        }
        
        public static string GetPreviousMember(string CurrentMember)
        {
            string MembershipNumber = null;

            try
            {
                using(var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.member prev = (from x in db.members

                                .Where(x => String.Compare(x.MembershipNumber, CurrentMember) < 0)

                                orderby x.MembershipNumber descending select x).FirstOrDefault();

                    if(prev != null)
                    {
                        MembershipNumber = prev.MembershipNumber;
                    }
                }
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }
            return MembershipNumber;
        }

        public static string GetNextMember(string CurrentMember)
        {
            string MembershipNumber = null;

            try
            {
                using (var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.member prev = (from x in db.members

                                .Where(x => String.Compare(x.MembershipNumber, CurrentMember) > 0)

                                   orderby x.MembershipNumber ascending
                                   select x).FirstOrDefault();

                    if (prev != null)
                    {
                        MembershipNumber = prev.MembershipNumber;
                    }
                }
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Error);
            }
            return MembershipNumber;
        }

        public static string LoadMembersRecords()
        {
            string sql = "select \"saccobook.members\".\"MembershipNumber\",\"saccobook.members\".\"MembershipType\",\"saccobook.members\".\"Name\",\"saccobook.members\".\"PhoneNumber\",\"saccobook.members\".\"Email\",\"saccobook.members\".\"NationalIdNumber\",\"saccobook.members\".\"Gender\",\"saccobook.members\".\"DateJoined\" from \"saccobook\".\"members\" \"saccobook.members\"";
            return sql;
        }
    }

    class Member
    {
        public string MembershipNumber { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternativeNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string NationalIdNumber { get; set; }
        public string TaxPIN { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public string Password { get; set; }
        public string SourceOfIncome { get; set; }
        public string Employer { get; set; }
        public string JobPosition { get; set; }
        public string PayrollNumber { get; set; }
        public string EmployerAddress { get; set; }
        public string EmployerTelephoneNumber { get; set; }
        public double GrossMonthlyIncome { get; set; }
        public DateTime DateJoined { get; set; }
        public string MembershipStatus { get; set; }
        public string MembershipType { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedAt { get; set; }
        
    }
}
