using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SaccoBook.AppResources
{
    class XMLFormatter
    {
        static string path = AppDomain.CurrentDomain.BaseDirectory + AppConstants.GetXMLFilePath();
        /**
        * Function Updates Content in the Config file XML Node
        */
        public static void UpdateXMLNode(string ThemeName)
        {
           
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(path);
                doc.SelectSingleNode("Settings/ActiveSkin").InnerText = ThemeName;

                doc.Save(path); //This will save the changes to the file.

            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        /**
        * Function returns Content in the Config file XML Node
        */
        public static string GetContent(string TagName)
        {
            string url = "";
            try
            {

                if (File.Exists(path))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(path);
                    XmlNode WebServiceNameNode = doc.GetElementsByTagName(TagName)[0];

                    url = WebServiceNameNode.InnerText;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Sacco Book", ex.ToString(),
                                       System.Diagnostics.EventLogEntryType.Warning);
            }
            return url;
        }
    }
}
