using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaccoBook.AppResources
{
    class AppFunctions
    {
        [DllImport("wininet.dll")]
        private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        static string connectionstring = AppResources.DatabaseConnection.ConnectionString();
        /**
         * Function checks if host machine has internet connection
         */
        public static bool IsInternetAvailable()
        {
            int description;
            return InternetGetConnectedState(out description, 0);
        }
        /**
        * Function sends SMS message to specified reciepient using Africastalking SMS gateway
        */
        public static bool SendTextMessage(string recipts, string message)
        {
            bool _status = false;

            if (true)
            {
                string status = null;

                var recipients = recipts;

                string timenow = DateTime.Now.ToString("yyyy-MM-d");

                string username = AppConstants.GetAfricastalkingUsername();

                string apiKey = AppConstants.GetAfricastalkingAPIKey();

            }
            return _status;
        }
        /*
        * Function Formats Document Number 
          param - LastAutoIncrementId - Last AutoInctrement Value from source table
          param - DocumentPrefix - Document Prefix for Document as defined by user e.g "EXP,EMP,LOANREP"
          param - DecimalPlaces - Number of characters after the DocumentPrefix e.g EXP000000001, EMP0001

          return - Formatted Document Number e.g EXP000001
        */
        public static string GetNewDocumentNumber(string NumberSeriesCode, string LastUsedNumber)
        {
            string RecordNumber = LastUsedNumber.Substring(NumberSeriesCode.Length);
            int DecimalPlaces = RecordNumber.Length;
            int LastAutoIncrementId = Convert.ToInt32(RecordNumber);

            string FormatterPrefix = "";
            string fmt = ".##";       
            
            char pad = '0';
            FormatterPrefix = FormatterPrefix.PadLeft(DecimalPlaces, pad);
            FormatterPrefix = FormatterPrefix + fmt;

            int NextAutoIncrementId = LastAutoIncrementId + 1;
            return NumberSeriesCode + NextAutoIncrementId.ToString(FormatterPrefix);
        }
        /**
        * Function exports grid to specified format
        */
        public static void Export(string ext, DevExpress.XtraGrid.GridControl grid)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = ext;
                if (saveDialog.ShowDialog() != DialogResult.Cancel)
                {
                    string exportFilePath = saveDialog.FileName;
                    string fileExtenstion = new FileInfo(exportFilePath).Extension;

                    switch (fileExtenstion)
                    {
                        case ".xls":
                            grid.ExportToXls(exportFilePath);
                            break;
                        case ".xlsx":
                            grid.ExportToXlsx(exportFilePath);
                            break;
                        case ".rtf":
                            grid.ExportToRtf(exportFilePath);
                            break;
                        case ".pdf":
                            grid.ExportToPdf(exportFilePath);
                            break;
                        case ".html":
                            grid.ExportToHtml(exportFilePath);
                            break;
                        case ".mht":
                            grid.ExportToMht(exportFilePath);
                            break;
                        default:
                            break;
                    }

                    if (File.Exists(exportFilePath))
                    {
                        try
                        {
                            //Try to open the file and let windows decide how to open it.
                            System.Diagnostics.Process.Start(exportFilePath);
                        }
                        catch(Exception ex)
                        {
                            System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
                            string msg = "The file could not be opened." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        }
                    }
                    else
                    {
                        string msg = "The file could not be saved." + Environment.NewLine + Environment.NewLine + "Path: " + exportFilePath;
                        XtraMessageBox.Show(msg, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static void CreateAppFolders()
        {
            if (!Directory.Exists(Application.StartupPath + @"\Photos"))
                Directory.CreateDirectory(Application.StartupPath + @"\Photos");

            if (!Directory.Exists(Application.StartupPath + @"\Attachments"))
                Directory.CreateDirectory(Application.StartupPath + @"\Attachments");

            if (!Directory.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppConstants.GetAppDocumentsFolderName())))
                Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), AppConstants.GetAppDocumentsFolderName()));
        }
       
        /**
        * Function Loads SearchLookUpEdit
        */
        public static void LoadSearchLookUpEdit(DevExpress.XtraEditors.SearchLookUpEdit _SearchLookUpEdit, string sql)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            try
            {
                DataSet _ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    _SearchLookUpEdit.Properties.DataSource = null;

                    _SearchLookUpEdit.Properties.DataSource = _ds.Tables[0];
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        public static void LoadTable(DevExpress.XtraGrid.GridControl grid, DevExpress.XtraGrid.Views.Grid.GridView gridview, string sql)
        {
            
        }
        public static void LoadTreeList(DevExpress.XtraTreeList.TreeList TreeList, string sql)
        {
            SqlConnection conn = new SqlConnection(connectionstring);
            conn.Open();
            try
            {
                DataSet _ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                sda.Fill(_ds);

                if (_ds.Tables.Count > 0)
                {
                    TreeList.DataSource = _ds.Tables[0];
                }

                conn.Close();
            }
            catch (SqlException ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        public static string ConvertTo_YYYY_MM_D_DateFormat(string Date)
        {
            string DateToSave = "";          

            try
            {
                DateTime dt = DateTime.Parse(Date);
                DateToSave = dt.ToString("yyyy-MM-d");
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }

            return DateToSave;
        }
        public static bool CheckIfAppIsActivated(string pass, string path)
        {
            RegistryKey regkey = Registry.CurrentUser;
            regkey = regkey.CreateSubKey(path); //path
            string Br = (string)regkey.GetValue("Password");
            if (Br == pass)
                return false; //good
            else
                return true;//bad
        }
    }
}
