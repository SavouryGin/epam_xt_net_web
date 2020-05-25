using System;

namespace Task_1_1_3_Another_triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n;
            bool done = false;
            Console.WriteLine("Hello! This program will draw an isosceles triangle.");
            while (!done)
            {
                Console.Write("Enter the height of your triangle: ");
                string n_str = Console.ReadLine();
                try
                {
                    n = Int32.Parse(n_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! The value you entered is not an integer. Try again!");
                    continue;
                }
                if (n < 1)
                {
                    Console.WriteLine("Error! The value you entered is less than one. Try again!");
                    continue;
                }
                else
                {
                    Console.WriteLine("Here is your triangle:");
                    int indent_len = n - 1; // Indent spaces
                    for (int i = 1; i <= n; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Font Green
                        int a_i = 1 + (i - 1) * 2; // Next number of the arithmetic progression
                        string s = new string('*', a_i); // Number of asterisks                                         
                        string indent = new string(' ', indent_len); // Indentation
                        string res = indent + s; // Result string
                        indent_len -= 1;                        
                        Console.WriteLine(res);

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
