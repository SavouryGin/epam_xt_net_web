using System;

namespace Task_1_1_4_X_mas_tree
{
    class Program
    {
        static void Main(string[] args)
        {
            int q;
            bool done = false;
            Console.WriteLine("Hello! This program will draw a Christmas tree.");
            while (!done)
            {
                Console.Write("Enter the height of your Christmas tree: ");
                string q_str = Console.ReadLine();
                try
                {
                    q = Int32.Parse(q_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! The value you entered is not an integer. Try again!");
                    continue;
                }
                if (q < 1)
                {
                    Console.WriteLine("Error! The value you entered is less than one. Try again!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Here is your Christmas tree:");
                    Console.ForegroundColor = ConsoleColor.Green; // Font Green
                    string indent_star = new string(' ', q);
                    string star = indent_star + "*"; 
                    Console.WriteLine(star); // Christmas tree star
                    int indent_len_1 = q - 1; // Outer spaces
                    for (int j = 1; j <= q; j++)
                    {
                        int n = j + 1;
                        int indent_len_2 = n - 1 + indent_len_1; // Inner spaces
                        for (int i = 1; i <= n; i++)
                        {
                            int a_i = 1 + (i - 1) * 2; // Next number of the arithmetic progression
                            string s = new string('*', a_i); // Number of asterisks                                         
                            string indent = new string(' ', indent_len_2); // Indentation
                            string res = indent + s; // Result string
                            indent_len_2 -= 1;
                            Console.WriteLine(res);
                        }
                        indent_len_1 -= 1;
                    }                  
                    Console.ResetColor(); // Return the default color
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
            }
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
