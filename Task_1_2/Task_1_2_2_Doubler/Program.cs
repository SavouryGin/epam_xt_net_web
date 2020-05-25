using System;
using System.Linq;

namespace Task_1_2_2_Doubler
{
    class Program
    {        
        static void Main(string[] args)
        {
            bool done = false;
            Console.WriteLine("Hello! This program will double those characters from the first entry that are in the second entry.");

            while (!done)
            {
                Console.WriteLine("Entry 1: ");
                string entry_1 = Console.ReadLine();
                Console.WriteLine("Entry 2: ");
                string entry_2 = Console.ReadLine();
                if (entry_1.Length < 1 || entry_2.Length < 1)
                {
                    Console.WriteLine("One of your entries is empty. Try again!");
                    continue;
                }
                
                char[] to_check = entry_2.ToCharArray();
                char[] uniques = to_check.Distinct().ToArray();
                string result = entry_1;
                foreach (char c in uniques)
                {
                    if (entry_1.Contains(c))
                    {
                        string d = c.ToString() + c.ToString();                        
                        result = result.Replace(c.ToString(),d);
                    }
                }

                Console.WriteLine("Result: \n" + result);
                Console.Write("Type 'yes' if you want to continue or something else to break: ");
                string ans = Console.ReadLine();
                if (ans == "yes" || ans == "y")
                {
                    continue;
                }
                else
                {
                    done = true;
                }
            }
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
