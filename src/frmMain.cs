using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace Launcher
{
    public partial class frmMain : Form
    {
        private String dirPath = Application.StartupPath;

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

            var webClient = new WebClient();
            string readHtml = webClient.DownloadString("your_file_path_url");

            return returnVersion;
        }
    }
}
