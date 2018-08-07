using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;

namespace ListDirectory
{
    static class Program
    {
        public static string DirectoryPath;
        public static bool ExcludeDir;
        public static bool ExcludeFile;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            DirectoryPath = "";
            ExcludeDir = false;
            ExcludeFile = false;

            switch(getParentProcess())
            {
#if DEBUG
                case "devenv":
                    //loadCommandArgs(args);
                    //break;
#endif

                case "cmd":
                    runFromCmd(args);
                    break;

                case "explorer":
                    runFromExplorer();
                    break;

                default:
                    MessageBox.Show("Could not get parent process name.", "Unspecified error.", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    break;
            }            
        }

        public static void ListFoldersAndFiles(string path, out List<string> dir, out List<string> file)
        {
            if(!string.IsNullOrWhiteSpace(path))
            {
                dir = Directory.GetDirectories(path).ToList();
                file = Directory.GetFiles(path).ToList();
            }
            else
            {
                dir = new List<string>();
                file = new List<string>();
            }
        }

        private static string getParentProcess()
        {
            var myId = Process.GetCurrentProcess().Id;
            var query = string.Format("SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = {0}", myId);
            var search = new ManagementObjectSearcher("root\\CIMV2", query);
            var results = search.Get().GetEnumerator();
            results.MoveNext();
            var queryObj = results.Current;
            var parentId = (uint)queryObj["ParentProcessId"];
            var parent = Process.GetProcessById((int)parentId);
            return parent.ProcessName;
        }

        private static void runFromCmd(string[] args)
        {
            loadCommandArgs(args);

            List<string> dir = new List<string>();
            List<string> file = new List<string>();
            ListFoldersAndFiles(DirectoryPath, out dir, out file);

            List<string> items = new List<string>();
            if(!ExcludeDir)
            {
                items.AddRange(dir);
            }

            if(!ExcludeFile)
            {
                items.AddRange(file);
            }

            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            //Get directory contents
            //Remove exclusions
            //Send to supplied text document
        }

        private static void runFromExplorer()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }

        private static void loadCommandArgs(string[] args)
        {
            List<string> arguments = args.ToList();
            if(args.Length == 0)
            {
                displayHelp();
                return;
            }
            foreach (string arg in arguments)
            {
                switch (arg)
                {
                    case "-dir":
                        int index = arguments.IndexOf(arg);
                        if(index + 1 != arguments.Count)
                        {
                            string value = arguments[index + 1];
                            value = value.Replace("\"", "");
                            if (Directory.Exists(value))
                            {
                                DirectoryPath = value;
                            }
                            else
                            {
                                MessageBox.Show("Specified directory does not exist.", "Directory not found!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No directory specified.", "Invalid number of arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }                        
                        break;

                    case "-ed":
                        ExcludeDir = true;
                        break;

                    case "-ef":
                        ExcludeFile = true;
                        break;

                    case "-?":
                        displayHelp();
                        break;
                }
            }
        }

        private static void displayHelp()
        {
            Console.WriteLine("-dir\tPath of directory to list contents.");
        }
    }
}
