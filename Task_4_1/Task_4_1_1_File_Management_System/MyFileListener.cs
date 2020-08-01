using System;
using System.Globalization;
using System.IO;

namespace Task_4_1_1_File_Management_System
{
    internal class MyFileListener
    {
        protected FileSystemWatcher watcher = null;
        protected string pathToDirectory;
        protected string pathToArchive;
        protected string pathToLogFiles;
        protected int changeCounter;
        protected readonly int saveFrequency;

        public MyFileListener(string pathToDir, string pathToArch, string pathToLog,  int num)
        {
            // The directory will be saved after every {0}-th change
            changeCounter = num;
            saveFrequency = num;

            // Create an instance of class FileSystemWatcher
            watcher = new FileSystemWatcher();

            // Set the paths
            pathToDirectory = pathToDir;
            pathToArchive = pathToArch;
            pathToLogFiles = pathToLog;
            watcher.Path = pathToDirectory;

            // Specify targets for observation
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.FileName
                                 | NotifyFilters.DirectoryName;

            // Observe only text files
            watcher.Filter = "*.txt";

            // Observe in all nested catalogs
            watcher.IncludeSubdirectories = true;

            // Add event handlers
            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;

            // Start watching directory
            watcher.EnableRaisingEvents = true;            
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            string message = string.Format("Change file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }

        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            
            string message = string.Format("Create file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ResetColor();

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }

        private void OnDeleted(object sender, FileSystemEventArgs e)
        {
            string message = string.Format("Delete file: '{0}'", e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }           
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string message = string.Format("Rename file: from '{0}' to '{1}'", e.OldFullPath, e.FullPath);
            MyLogger.LogChanges(message, pathToLogFiles);
            changeCounter--;

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();

            if (changeCounter == 0)
            {
                MyArchiver.SaveChanges(pathToDirectory, pathToArchive, pathToLogFiles);
                changeCounter = saveFrequency;
            }
        }     
    }
}
