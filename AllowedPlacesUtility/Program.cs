using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace APU
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            DirCheck();
        }
        private static void DirCheck()
        {
            if (!Directory.Exists(Properties.Settings.Default.GamePath))
            {
                string steampath = SteamPath();
                if (steampath != "")
                {
                    Properties.Settings.Default.GamePath = steampath.Replace("/", "\\") + @"\steamapps\common\Car Mechanic Simulator 2018";
                    Properties.Settings.Default.ShopPath = steampath.Replace("/", "\\") + @"\steamapps\workshop\content\645630";
                    Properties.Settings.Default.Save();
                }
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.Description = "Select Your Car Mechanic Simulator 2018 Installation Folder.";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.GamePath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    fbd.Description = "Select A Folder With Any Additional (Workshop) Cars, Or Cancel To Continue.";
                    if (fbd.ShowDialog() == DialogResult.OK)
                    {
                        Properties.Settings.Default.ShopPath = fbd.SelectedPath;
                    }
                    Properties.Settings.Default.Save();
                    Application.Run(new FormMain());
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Run(new FormMain());
            }
        }
        private static string SteamPath()
        {
            object path = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Valve").OpenSubKey("Steam").GetValue("SteamPath");
            if (path != null)
                return path as string;
            else
                return "";
        }
    }
}
