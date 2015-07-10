using System;
using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.IO;
//using System.Linq;
//using System.Text;
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
            //TODO: check for subfolders
            List<String> folders = new List<String>();
            string latestVersion = "0.5";
            foreach (string subFolderPath in Directory.GetDirectories(dirPath, "*", SearchOption.TopDirectoryOnly))
            {
                Console.WriteLine(subFolderPath);
                string fullPath = Path.GetFullPath(subFolderPath).TrimEnd(Path.DirectorySeparatorChar);
                string subFolderName = Path.GetFileName(fullPath);
                Console.WriteLine(subFolderName);

                var version1 = new Version(latestVersion);
                var version2 = new Version(subFolderName);

                var result = version1.CompareTo(version2);
                if (result > 0)
                    Console.WriteLine("latestVersion is greater");
                else if (result < 0)
                    Console.WriteLine("subFolderName is greater");
                else
                    Console.WriteLine("versions are equal");
            }

            //TODO: if at least one folder is available, store version of local version
            //TODO: check online for latest version number
            //TODO: if online is newer, download
            //TODO: else launch local app
        }

        private void btnCheckOnline_Click(object sender, EventArgs e)
        {
        }

    }
}
