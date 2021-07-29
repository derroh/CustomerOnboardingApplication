using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaccoBook.AppResources
{
    class DatabaseConnection
    {
        //function returns the database connection string
        public static string ConnectionString()
        {
            //Get Database Connection String from App.Config file 

            string ConnectionString = null;

            //ConnectionStringSettings connectionStringSettings = ConfigurationManager.ConnectionStrings["SaccoBookConnection"];
            
            return ConnectionString;
        }
        //function checks if database is reachable
        public static bool IsDatabaseReachable(string _ConnectionString)
        {
            bool status = false;    

            string connectionString = string.Format(_ConnectionString);
            try
            {
                SqlHelper helper = new SqlHelper(connectionString);

                if (helper.IsConnection)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
            return status;
        }
    }
    public class SqlHelper
    {
        SqlConnection cn;
        public SqlHelper(string connectionString)
        {
            cn = new SqlConnection(connectionString);
        }

        public bool IsConnection
        {
            get
            {
                if (cn.State == System.Data.ConnectionState.Closed)
                    cn.Open();
                return true;
            }
        }
    }
}
