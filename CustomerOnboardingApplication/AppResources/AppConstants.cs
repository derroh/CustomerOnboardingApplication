using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaccoBook.AppResources
{
    class AppConstants
    {
        /*
        * Define App Constant Values Here
        */
        const int _TrialPeriod = 30;
        const string _AppPassword = "LF8Y8-GN3QH-T84XB-QVY3B-RC4DF"; // Set Activation Key Here
        const string _GlobalPath = @"Software\SaccoBook\Protection"; // Set path to Registry Here
        const string _AppDocumentsFolderName = "SaccoBook"; //Set Name for App folder Documents Folder     
        const string _XMLFilePath =  @"\settings.xml"; //Set Name for settings file Here
        const string _SoftwareName = "Sacco Book"; //Set Name for settings file Here
        const string _CleanDatabasePath = "";
        const string _TestDatabasePath = "";
        const string _Currency = "Ush";
        const bool _IsNotificationsEnabled = false;


        /**
        * Function returns defined trial period in days
        */
        public static int GetTrialPeriod()
        {
            return _TrialPeriod;
        }
        /**
        * Function returns defined Software Activation Key
        */
        public static string GetAppPassword()
        {
            return _AppPassword;
        }
        /**
        * Function returns defined Software path in registry
        */
        public static string GetGlobalPath()
        {
            return _GlobalPath;
        }
        /**
        * Function returns defined Software Documents Folder Name
        */
        public static string GetAppDocumentsFolderName()
        {
            return _AppDocumentsFolderName;
        }      
        
        /**
        * Function returns defined config file path
        */
        public static string GetXMLFilePath()
        {
            return _XMLFilePath;
        }
        /**
        * Function returns defined Software Name
        */
        public static string GetSoftwareName()
        {
            string GetSystemSettingsResponse = "Customer Onboarding App";
            dynamic GetSystemSettingsResponseObject = JObject.Parse(GetSystemSettingsResponse);

            string SaccoName = GetSystemSettingsResponseObject.Name;

            return SaccoName;
        }
        /**
        * Function returns definedClean database path
        */
        public static string GetCleanDatabasePath()
        {
            return _CleanDatabasePath;
        }
        /**
        * Function returns defined Test Database path
        */
        public static string GetTestDatabasePath()
        {
            return _TestDatabasePath;
        }
        /**
        * Function returns Africastalking Username
        */
        public static string GetAfricastalkingUsername()
        {
            return "";
        }
        /**
        * Function returns Africastalking API Key
        */
        public static string GetAfricastalkingAPIKey()
        {
            return "";
        }
        /**
        * Function returns Server SMTP Port
        */
        public static int GetServerSMTPPort()
        {
            
            return 0;
        }
        /**
        * Function returns Server SMTP Port
        */
        public static string GetServerSMTPServer()
        {
            
            return "";
        }
        /**
        * Function returns Server SMTP User Id
        */
        public static string GetServerSMTPUserId()
        {
            return "";
        }
        /**
        * Function returns Server SMTP PUser Password
        */
        public static string GetServerSMTPUserPassword()
        {
            return "";
        }
        /**
        * Function returns defined Currency
        */
        public static string GetCurrency()
        {
            return _Currency;
        }
        /**
        * Function returns True ir false if Automatic Database BackUp is enabled
        */
        public static bool IsAutomaticDatabaseBackUpEnabled()
        {
            return false;
        }
        /**
        * Function returns the system credential type (Windows Authentication/UserPassword)
        */
        public static string GetSystemCredentialType()
        {
            return "";
        }
        /**
        * Function returns the Database backUp path
        */
       

        /**
        * Function returns true of false if Notifications are enabled
        */
        public static bool IsSytemNotificationsEnabled()
        {
            return _IsNotificationsEnabled;
        }

    }
}
