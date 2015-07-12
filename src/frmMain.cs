﻿using System;
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

            foreach (string subFolderPath in Directory.GetDirectories(dirPath, "*", SearchOption.TopDirectoryOnly))
            {
                Console.WriteLine(subFolderPath);
                string fullPath = Path.GetFullPath(subFolderPath).TrimEnd(Path.DirectorySeparatorChar);
                string subFolderName = Path.GetFileName(fullPath);
                Console.WriteLine(subFolderName);

                var subFolderVersion = new Version(subFolderName);

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

            //TODO: check online for latest version number
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
            //http://stackoverflow.com/questions/29695517/read-online-txt-file
            //http://stackoverflow.com/questions/2471209/how-to-read-a-file-from-internet

            var returnVersion = new Version("0.0");

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
                    Console.WriteLine("updateVersion:" + updateVersion);

                    updateChangelog = item["changelog"].InnerText;
                    Console.WriteLine("updateChangelog:" + updateChangelog);

                    updateUrl = item["url"].InnerText;
                    Console.WriteLine("updateUrl:" + updateUrl);
                }

                Version localVersion = Assembly.GetCallingAssembly().GetName().Version;
                Console.WriteLine("localVersion:" + localVersion.ToString());

                ////////////////////////
                var result = localVersion.CompareTo(updateVersion);
                if (result > 0)
                {
                    Console.WriteLine("localVersion is greater");
                }
                else if (result < 0)
                {
                    Console.WriteLine("updateVersion is greater");
                }
                else
                {
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
