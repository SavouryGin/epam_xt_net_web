using System;

namespace Task_1_1_2_Triangle
{
    class Triangle
    {
        static void Main(string[] args)
        {
            int n;
            bool done = false;
            Console.WriteLine("Hello! This program will draw a right triangle.");
            while (!done)
            {
                Console.Write("Enter the height of the triangle: ");
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
                    for (int i = 1; i <= n; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Green; // Font Green
                        Console.WriteLine(new string('*', i));

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
