using System;
using System.IO;
using System.IO.Compression;
using System.Collections.Generic;

namespace Task_4_1_1_File_Management_System
{
    internal static class MyFileRestorer
    {
        internal static void UnzipArchiveWithReplace(string archiveName, string directoryName, 
            string pathToArchive, string pathToLog)
        {
            string zipPath = pathToArchive + "\\" + archiveName;
            string extractPath = directoryName;
            string logPath = pathToLog;

            try
            {
                Directory.Delete(directoryName, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't delete old directory: " + ex.Message);
                return;
            }

            try
            {
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                string message = string.Format("Rollback to: {0}", archiveName);
                MyLogger.LogChanges(message, logPath);

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("All data has been successfully restored!");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't extract archive: " + ex.Message);
            }
        }

        internal static Dictionary<string, string> GetAvailableArchives(string pathToArchive)
        {
            DirectoryInfo arch = new DirectoryInfo(pathToArchive);
            FileInfo[] Files = arch.GetFiles("*.zip");

            Dictionary<string, string> listOfArchives = new Dictionary<string, string>();

            int archId = 1;

            foreach (FileInfo file in Files)
            {
                listOfArchives[archId.ToString()] = file.Name;
                archId++;
            }

            return listOfArchives;
        }

        internal static string ParseArchiveName(string name)
        {
            var parseArchiveName = name.Split(new[] { '_', '.' }, StringSplitOptions.RemoveEmptyEntries);

            string[] time = parseArchiveName[0].Split(new[] { '-' });
            string[] date = parseArchiveName[1].Split(new[] { '-' });

            string res = string.Format("Time: {0}h {1}m {2}s, Date: {3}.{4}.{5}, GUID: {6}",
                time[0], time[1], time[2],
                date[0], date[1], date[2],
                parseArchiveName[2]);

            return res;
        }
    }
}
