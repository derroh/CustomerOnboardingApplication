using DevExpress.XtraEditors;
using Newtonsoft.Json;
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
    class SystemUserQueries
    {
        static string connectionstring = AppResources.DatabaseConnection.ConnectionString();

        public static string GetSystemUsers()
        {
            string sql = @"SELECT [Username]
                          ,[WindowsUsername]
                          ,[RoleID]
                          ,[FirstName]
                          ,[LastName]
                          ,[IdNumber]
                          ,[PhoneNumber]
                          ,[Status]
                          ,[LastModifiedBy]
                          ,[LastModifiedAt]
                      FROM [saccobook].[systemusers]";
            return sql;
        }

        /**
         * Function checks if there exists any users in the database when Application is run
         * @return bool | True if there's a user or false when there is non                    
         */

        public static bool IsThereAnyUsers()
        {
            bool status = false;

            string sql = @"SELECT * FROM [saccobook].[systemusers]";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    status = true;
                }
                conn.Close();
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }

            return status;
        }

        public static int CountUsers()
        {
            int count = 0;

            string sql = @"SELECT COUNT(*) as Records FROM [saccobook].[systemusers]";

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    count = Convert.ToInt32(reader["Records"].ToString());
                }
                conn.Close();
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Warning);
            }

            return count;
        }

        /**
        * Function creates system user 
        * @param Username | The user's username
        * @param RoleID | The user's role ID
        * @param FirstName | The user's first name
        * @param LastName | The user's last name
        * @param Password | The user's login password
        * @param IdNumber | The user's ID number
        * @param PhoneNumber | The user'sphone number 
        * @param LastModifiedBy | The user that last modified the recoed
        * @param LastModifiedAt | The time that the record was last modified

        * @return bool | return true if user is created / return false if not saved
        */
        public static bool CreateUser(string Username, string WindowsUsername, string RoleID, string FirstName, string LastName, string Password, string IdNumber, string PhoneNumber, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();

                string sql = @"INSERT INTO [saccobook].[systemusers]
                               ([Username]
                               ,[WindowsUsername]
                               ,[RoleID]
                               ,[FirstName]
                               ,[LastName]
                               ,[Password]
                               ,[IdNumber]
                               ,[PhoneNumber]
                               ,[Status]
                               ,[LastModifiedBy]
                               ,[LastModifiedAt])
                         VALUES
                               (@Username, @WindowsUsername, @RoleID, @FirstName
                               , @LastName
                               , @Password
                               , @IdNumber
                               , @PhoneNumber
                               , @Status
                               , @LastModifiedBy
                               , @LastModifiedAt)";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@WindowsUsername", WindowsUsername);
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@IdNumber", IdNumber);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", "Active");
                    cmd.Parameters.AddWithValue("@LastModifiedBy", LastModifiedBy);
                    cmd.Parameters.AddWithValue("@LastModifiedAt", LastModifiedAt);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status = true;
                }
            }

            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Warning);
            }
            return status;
        }
        /**
       * Function updates system user information
       * @param Username | The user's username
       * @param RoleID | The user's role ID
       * @param FirstName | The user's first name
       * @param LastName | The user's last name
       * @param Password | The user's login password
       * @param IdNumber | The user's ID number
       * @param PhoneNumber | The user'sphone number 
       * @param LastModifiedBy | The user that last modified the recoed
       * @param LastModifiedAt | The time that the record was last modified

       * @return bool | return true if user is created / return false if not saved
       */
        public static bool UpdateUser(string Username, string WindowsUsername, string RoleID, string FirstName, string LastName, string Password, string IdNumber, string PhoneNumber, string Status, string LastModifiedBy, string LastModifiedAt)
        {
            bool status = false;
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();

                string sql = @"UPDATE [saccobook].[systemusers] SET Username=@Username, WindowsUsername=@WindowsUsername, RoleID=@RoleID,FirstName=@FirstName,LastName=@LastName,Password=@Password,IdNumber=@IdNumber,PhoneNumber=@PhoneNumber, Status=@Status,LastModifiedBy=@LastModifiedBy,LastModifiedAt=@LastModifiedAt WHERE @Username";

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@WindowsUsername", WindowsUsername);
                    cmd.Parameters.AddWithValue("@RoleID", RoleID);
                    cmd.Parameters.AddWithValue("@FirstName", FirstName);
                    cmd.Parameters.AddWithValue("@LastName", LastName);
                    cmd.Parameters.AddWithValue("@Password", Password);
                    cmd.Parameters.AddWithValue("@IdNumber", IdNumber);
                    cmd.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);
                    cmd.Parameters.AddWithValue("@Status", Status);
                    cmd.Parameters.AddWithValue("@LastModifiedBy", LastModifiedBy);
                    cmd.Parameters.AddWithValue("@LastModifiedAt", LastModifiedAt);
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    status = true;
                }
            }

            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Warning);
            }
            return status;
        }
        /**
        * Function deletes system user 
        * @param Username | The user's Username
        * @return bool | return true if user is deleted / return false if not deleted
        */
        public static bool DeleteUser(string Username)
        {
            bool status = false;

            string sql = "DELETE FROM [saccobook].[systemusers] WHERE Username = @Username";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.AddWithValue("@Username", Username);
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                conn.Close();

                status = true;

            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }
            return status;
        }
        /**
        * Function returns system user information
        * @param Username | The user's Username
        * @return string | returns JSON string with user data
        */
        public static string GetuserProfileInfo(string Username)
        {
            string userdata = "";

            string RoleID = ""; string FirstName = ""; string LastName = ""; string Password = ""; string IdNumber = ""; string PhoneNumber = ""; string Status = ""; string LastModifiedBy = ""; string LastModifiedAt = "";

            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [saccobook].[systemusers] WHERE Username = '" + Username + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {

                    Username = dr.GetString(0);
                    RoleID = dr.GetString(1);
                    FirstName = dr.GetString(2);
                    LastName = dr.GetString(3);
                    Password = dr.GetString(4);
                    IdNumber = dr.GetString(5);
                    PhoneNumber = dr.GetString(6);
                    Status = dr.GetString(7);
                    LastModifiedBy = dr.GetString(8);
                    LastModifiedAt = dr.GetString(9);

                }
                conn.Close();

                var _SystemUser = new SystemUser
                {
                    Username = Username,
                    RoleId = RoleID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password,
                    IdNumber = IdNumber,
                    PhoneNumber = PhoneNumber,
                    Status = Status,
                    LastModifiedBy = LastModifiedBy,
                    LastModifiedAt = LastModifiedAt
                };
                userdata = JsonConvert.SerializeObject(_SystemUser);
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }
            return userdata;
        }
        /**
        * Function returns system user information
        * @param WindowsUsername | The user's WindowsUsername
        * @return string | returns JSON string with user data
        */
        public static string GetuserRoleIDByWindowsUsername(string WindowsUsername)
        {
            string userdata = "";

            string RoleID = ""; 

            SqlConnection conn = new SqlConnection(connectionstring);
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM [saccobook].[systemusers] WHERE WindowsUsername = '" + WindowsUsername + "'", conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    WindowsUsername = dr.GetString(0);
                    RoleID = dr.GetString(1);
                }
                conn.Close();

                var _SystemUser = new SystemUser
                {
                    Username = WindowsUsername,
                    RoleId = RoleID
                };
                userdata = JsonConvert.SerializeObject(_SystemUser);
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }
            return userdata;
        }
        /**
        * Function checks if user with specified username and password exists in system
        */
        public static string UserLogin(string Username, string Password)
        {
            string userdata = "";           

            string RoleID = ""; string FirstName = ""; string LastName = "";  string IdNumber = ""; string PhoneNumber = ""; string Status = ""; string CredentialType = "";
            try
            {
                using (var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.systemuser _member = db.systemusers.Where(x => x.Username == Username && x.Password == Password).SingleOrDefault();

                    if (_member != null)
                    {
                        Username = _member.Username;
                        Status = _member.Status;
                        RoleID = _member.RoleID;
                    }
                }

                var _SystemUser = new SystemUser
                {
                    Username = Username,
                    CredentialType = CredentialType,
                    RoleId = RoleID,
                    FirstName = FirstName,
                    LastName = LastName,
                    Password = Password,
                    IdNumber = IdNumber,
                    PhoneNumber = PhoneNumber,
                    Status = Status
                };
                userdata = JsonConvert.SerializeObject(_SystemUser);
            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                System.Diagnostics.EventLogEntryType.Warning);
            }
            return userdata;
        }

        public static bool CheckUserLogin(string Username, string Password)
        {
            bool status = false;
            try
            {
                using (var db = new CustomerOnboardingApplication.EF.OnboardEntities())
                {
                    CustomerOnboardingApplication.EF.systemuser _member = db.systemusers.Where(x => x.Username == Username && x.Password == Password).SingleOrDefault();

                    if (_member != null)
                    {
                        status = true;
                    }
                }

            }
            catch (Exception es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Warning);
            }
            return status;
        }
        /**
        * Function returns list of active system users
        */
        public static string[] GetActiveSystemUserList()
        {
            List<string> list = new List<string>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connectionstring;
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT Username FROM [saccobook].[systemusers] WHERE Status ='Active'", conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(reader.GetString(0));
                }
            }
            catch (SqlException es)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", es.ToString(),
                                  System.Diagnostics.EventLogEntryType.Warning);
            }
            return list.ToArray();
        }
    }

    class SystemUser
    {
        public static string SystemId { get; set; }
        public string Username { get; set; }
        public string CredentialType { get; set; }
        public string RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public string LastModifiedBy { get; set; }
        public string LastModifiedAt { get; set; }
    }
}
