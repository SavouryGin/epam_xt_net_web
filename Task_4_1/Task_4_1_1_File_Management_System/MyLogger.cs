using System;
using System.IO;

namespace Task_4_1_1_File_Management_System
{
    internal static class MyLogger
    {
        internal static void LogChanges(string message, string pathToLogFiles)
        {
            string path = pathToLogFiles;
            string fileName = string.Format("{0}_{1}_{2}{3}",
                DateTime.Now.Day,
                DateTime.Now.Month,
                DateTime.Now.Year,
                ".log");

            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);

                if (!dir.Exists)
                    dir.Create();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create log folder: " + ex.Message);
            }

            try
            {
                StreamWriter file = new StreamWriter(path + "/" + fileName, true);
                file.WriteLine(DateTime.Now + " | " + message);
                file.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Can't create log file: " + ex.Message);
            }
        }

        internal static void ViewLogs(string pathToLogFiles)
        {
            DirectoryInfo logs = new DirectoryInfo(pathToLogFiles);
            FileInfo[] LogFiles = logs.GetFiles("*.log");

            if (LogFiles.Length == 0)
            {
                Console.WriteLine("You don't have any logs yet.");
                return;
            }

            foreach (FileInfo file in LogFiles)
            {
                Console.WriteLine("#### Log '{0}' ####", file.Name);
                using (StreamReader sr = new StreamReader(pathToLogFiles + "\\" + file.Name))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine("\t" + line);
                    }
                }
            }
        }
    }
}
