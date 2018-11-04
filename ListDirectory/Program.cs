using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Windows.Forms;
using System.Text;

namespace ListDirectory
{
    static class Program
    {
        public static string DirectoryPath;
        public static bool ExcludeDir;
        public static bool ExcludeFile;
        public static bool ExcludeExtensions;
        public static string OutputPath;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            DirectoryPath = "";
            ExcludeDir = false;
            ExcludeFile = false;
            ExcludeExtensions = false;
            OutputPath = "";

            switch(getParentProcess())
            {
#if DEBUG
                case "devenv":
                    runFromExplorer();
                    break;
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

        public static List<string> GetFolderAndFileNames(List<string> items, bool showExtensions)
        {
            List<string> returnItems = new List<string>();
            foreach (var item in items)
            {
                if(showExtensions)
                {
                    returnItems.Add(Path.GetFileName(item));
                }
                else
                {
                    returnItems.Add(Path.GetFileNameWithoutExtension(item));
                }                                
            }

            return returnItems;
        }

        public static void SaveOutputFile(string path, List<string> items)
        {
            if(!string.IsNullOrWhiteSpace(path))
            {
                if(!File.Exists(path))
                {
                    using (File.CreateText(path)) { }
                }
                using (StreamWriter streamWriter = new StreamWriter(path))
                {
                    foreach (var item in items)
                    {
                        streamWriter.WriteLine(item);
                    }
                }
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

            items = GetFolderAndFileNames(items, !ExcludeExtensions);
            if(string.IsNullOrWhiteSpace(OutputPath))
            {
                OutputPath = DirectoryPath + "\\" + Path.GetFileName(DirectoryPath) + ".txt";
            }
            SaveOutputFile(OutputPath, items);
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
                int index = arguments.IndexOf(arg);
                switch (arg.ToLower())
                {
                    case "-dir":
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

                    case "-ee":
                        ExcludeExtensions = true;
                        break;

                    case "-o":
                        if (index + 1 != arguments.Count)
                        {
                            string value = arguments[index + 1];
                            value = value.Replace("\"", "");
                            OutputPath = value;
                        }
                        else
                        {
                            MessageBox.Show("No directory specified.", "Invalid number of arguments", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;

                    case "-?":
                        displayHelp();
                        break;
                }
            }
        }

        private static void displayHelp()
        {
            StringBuilder helpOutput = new StringBuilder();
            helpOutput.AppendLine("-dir\tPath of directory to list contents.");
            helpOutput.AppendLine("-ed\tExclude directories.");
            helpOutput.AppendLine("-ef\tExclude files.");
            helpOutput.AppendLine("-ee\tExclude extensions.");
            helpOutput.AppendLine("-o\tOutput file path.");
            Console.WriteLine(helpOutput.ToString());
        }
    }
}
