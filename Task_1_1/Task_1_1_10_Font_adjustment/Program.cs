using System;

namespace Task_1_1_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            bool done = false;
            Console.WriteLine("Hello! This program will calculate the sum of all elements of \n" +
                "a two-dimensional array that are in an even position.");
            while (!done)
            {
                Console.Write("Enter the first dimension: ");
                string a_str = Console.ReadLine();
                Console.Write("Enter the second dimension: ");
                string b_str = Console.ReadLine();
                try
                {
                    a = Int32.Parse(a_str);
                    b = Int32.Parse(b_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! One of the values you entered is not an integer. Try again!");
                    continue;
                }
                if (a <= 0 || b <= 0)
                {
                    Console.WriteLine("Error! One of the values you entered is less than or equal to zero. Try again!");
                    continue;
                }
                else
                {
                    int[,] threedim = new int[a, b]; // Two-dimensional array
                    Random rnd = new Random();
                    int sum = 0;
                    Console.WriteLine("Random 2D-array:");
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {                            
                            int num = rnd.Next(-1000, 1000);
                            threedim[i, j] = num;
                            if ((i + j) % 2 == 0)
                            {
                                sum += num;
                            }
                            Console.Write("\t[{0},{1}] {2}  ", i+1, j+1, num);                            
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine("The sum of the elements in an even position is " + sum);
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
