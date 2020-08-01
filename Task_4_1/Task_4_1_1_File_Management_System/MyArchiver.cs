using System;
using System.IO;
using System.IO.Compression;

namespace Task_4_1_1_File_Management_System
{
    internal static class MyArchiver
    {
        internal static void SaveChanges(string pathToDirectory, string pathToArchive, string pathToLog)
        {
            string startPath = pathToDirectory;
            string logPath = pathToLog;
            Guid g = Guid.NewGuid();

            string archiveName = string.Format("{0}-{1}-{2}_{3}-{4}-{5}_{6}{7}",
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second,
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year,
                g,
                ".zip");

            string zipPath = pathToArchive;

            try
            {
                DirectoryInfo dir = new DirectoryInfo(zipPath);

                if (!dir.Exists)
                    dir.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create archive folder: " + ex.Message);
            }

            try
            {
                ZipFile.CreateFromDirectory(startPath, zipPath + "\\" + archiveName);
                string message = string.Format("Archive created: {0}", archiveName);
                MyLogger.LogChanges(message, logPath);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("The working directory was saved successfully in {0}!", zipPath);
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't zip files: " + ex.Message);
            }
        }
    }
}
