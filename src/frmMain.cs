using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace Launcher
{
    public partial class frmMain : Form
    {
        private String dirPath = Application.StartupPath;
        private String updateUrlXml = "https://raw.githubusercontent.com/greed77/Launcher/master/AutoUpdate.xml";

        public static string updateTitle = "";
        public static string updateUrl = "";
        public static Version updateVersion= new Version("0.0.0.0");
        public static string updateChangelog = "";
        public static string updateAction = "";

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCheckFolder_Click(object sender, EventArgs e)
        {
            List<String> folders = new List<String>();
            var latestVersion = new Version("0.0");
            latestVersion = new Version(Math.Max(0, latestVersion.Major), Math.Max(0, latestVersion.Minor), Math.Max(0, latestVersion.Build), Math.Max(0, latestVersion.Revision));

            foreach (string subFolderPath in Directory.GetDirectories(dirPath, "*", SearchOption.TopDirectoryOnly))
            {
                Console.WriteLine(subFolderPath);
                string fullPath = Path.GetFullPath(subFolderPath).TrimEnd(Path.DirectorySeparatorChar);
                string subFolderName = Path.GetFileName(fullPath);
                Console.WriteLine(subFolderName);

                var subFolderVersion = new Version(subFolderName);
                subFolderVersion = new Version(Math.Max(0, subFolderVersion.Major), Math.Max(0, subFolderVersion.Minor), Math.Max(0, subFolderVersion.Build), Math.Max(0, subFolderVersion.Revision));

                var result = latestVersion.CompareTo(subFolderVersion);
                if (result > 0)
                {
                    Console.WriteLine("latestVersion is greater");
                }
                else if (result < 0)
                {
                    Console.WriteLine("subFolderName is greater");
                    latestVersion = subFolderVersion;
                }
                else
                {
                    Console.WriteLine("versions are equal");
                }
            }
            Console.WriteLine(latestVersion);

            var onlineVersion = getOnlineVersion();

            //TODO: if online is newer, download

            //TODO: launch latest app
        }

        private void btnCheckOnline_Click(object sender, EventArgs e)
        {
            getOnlineVersion();
        }

        private Version getOnlineVersion()
        {
            var returnVersion = new Version("0.0");
            returnVersion = new Version(Math.Max(0, returnVersion.Major), Math.Max(0, returnVersion.Minor), Math.Max(0, returnVersion.Build), Math.Max(0, returnVersion.Revision));

            //////////////////////////////
            try
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(updateUrlXml);

                XmlNodeList items = xml.SelectNodes("/items/item");
                foreach (XmlNode item in items)
                {
                    updateTitle = item["title"].InnerText;
                    Console.WriteLine("updateTitle:" + updateTitle);

                    updateVersion = new Version(item["version"].InnerText);
                    updateVersion = new Version(Math.Max(0, updateVersion.Major), Math.Max(0, updateVersion.Minor), Math.Max(0, updateVersion.Build), Math.Max(0, updateVersion.Revision));
                    Console.WriteLine("updateVersion:" + updateVersion);

                    updateChangelog = item["changelog"].InnerText;
                    Console.WriteLine("updateChangelog:" + updateChangelog);

                    updateUrl = item["url"].InnerText;
                    Console.WriteLine("updateUrl:" + updateUrl);
                }

                Version localVersion = Assembly.GetCallingAssembly().GetName().Version;
                localVersion = new Version(Math.Max(0, localVersion.Major), Math.Max(0, localVersion.Minor), Math.Max(0, localVersion.Build), Math.Max(0, localVersion.Revision));
                Console.WriteLine("localVersion:" + localVersion);

                ////////////////////////
                var result = localVersion.CompareTo(updateVersion);
                if (result > 0)
                {
                    //MARK: shouldn't happen unless shenanigans
                    Console.WriteLine("localVersion is greater");
                }
                else if (result < 0)
                {
                    //MARK: new version available
                    Console.WriteLine("updateVersion is greater");

                    //TODO: download from url in xml
                }
                else
                {
                    //MARK: local version is current
                    Console.WriteLine("versions are equal");
                }
                ////////////////////////
            }
            catch (Exception level1)
            {
                Console.WriteLine(level1);
            }
            //////////////////////////////

            return returnVersion;
        }
    }
}
