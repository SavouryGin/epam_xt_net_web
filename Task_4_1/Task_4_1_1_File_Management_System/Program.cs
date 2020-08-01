using System;
using System.IO;
using System.Collections.Generic;

namespace Task_4_1_1_File_Management_System
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== My File Management System ===\n");

            // NB: Default parameters, change if necessary
            string pathToDirectory = @".\for_demo\text_samples";
            string pathToArchive = @".\for_demo\my_archive";
            string pathToLogFiles = @".\for_demo\my_logs";
            int saveFrequency = 5; // How often should the directory be saved


            bool done = false;

            while (!done)
            {
                Console.WriteLine("-------------------------------------------------------------------------");
                Console.WriteLine("Specify the program operation mode: \n" +
                "\t 'w' - watching mode (all changes will be tracked and saved) \n" +
                "\t 'r' - restoration mode (rollback changes to the selected point)\n" +                
                "\t 'l' - view logs\n" +
                "\t 'c' - clear archive and log files\n" +
                "\t 'e' - exit");

                string answer = Console.ReadLine().ToLower().Trim();

                switch (answer)
                {                    
                    case "w": // Watching mode

                        try
                        {
                            // Activate watching mode on specific directory 
                            MyFileListener w = new MyFileListener(
                                pathToDirectory, 
                                pathToArchive, 
                                pathToLogFiles, 
                                saveFrequency);

                            Console.WriteLine("*** Observation mode activated! ***");
                            Console.WriteLine("All changes in the directory '{0}' are now tracked.", pathToDirectory);

                            // Wait for the program termination command
                            done = true;
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.WriteLine("Press 'q' to stop the watching mode!");
                            Console.ResetColor();
                            while (Console.Read() != 'q') ;
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong! Try to change optional values." + ex.Message);
                            continue;
                        }                        

                    case "r": // Restoration mode

                        try
                        {
                            Dictionary<string, string> d = MyFileRestorer.GetAvailableArchives(pathToArchive);

                            if (d.Count == 0)
                            {
                                Console.WriteLine("You have not saved any archives.");
                                done = true;
                                continue;
                            }

                            Console.WriteLine("*** Restoration mode activated! ***");

                            Console.WriteLine("The following archives are available for recovery:");
                            
                            foreach (string arch in d.Keys)
                            {
                                Console.WriteLine("\t № {0}: {1}", arch, MyFileRestorer.ParseArchiveName(d[arch]));
                            }

                            Console.WriteLine("Enter archive number: ");
                            string num = Console.ReadLine().Trim();

                            if (!d.ContainsKey(num))
                            {
                                Console.WriteLine("Incorrect input! Try again.");
                                continue;
                            }

                            MyFileRestorer.UnzipArchiveWithReplace(d[num], pathToDirectory, pathToArchive, pathToLogFiles);

                            Console.WriteLine("Type 'yes' if you want to continue or something else to quit:");
                            string ans = Console.ReadLine().ToLower().Trim();

                            if (ans == "yes" || ans == "y")
                            {
                                continue;
                            }
                            else
                            {
                                done = true;
                                break;
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong! Try to change optional values." + ex.Message);
                            continue;
                        }

                    case "l":
                        MyLogger.ViewLogs(pathToLogFiles);

                        Console.WriteLine("Type 'yes' if you want to continue or something else to quit:");
                        string answ = Console.ReadLine().ToLower().Trim();

                        if (answ == "yes" || answ == "y")
                        {
                            continue;
                        }
                        else
                        {
                            done = true;
                            break;
                        }

                    case "c":
                        try
                        {
                            Directory.Delete(pathToArchive, true);
                            Directory.Delete(pathToLogFiles, true);
                            Console.WriteLine("Done! Deleted folders: {0}, {1}", pathToArchive, pathToLogFiles);
                            break;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Something went wrong! " + ex.Message);
                            continue;
                        }

                    case "e":
                        done = true;
                        break;

                    default:
                        Console.WriteLine("Incorrect input! Try again");
                        continue;
                }
            }            

            Console.WriteLine("Press any button to quit the app.");
            Console.ReadKey();                     
        }
    }
}
