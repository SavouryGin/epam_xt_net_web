using System;

namespace Task_1_1_8_No_positive
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            int c;
            bool done = false;
            Console.WriteLine("Hello! This program will replace all the negative elements \n" +
                "in a three-dimensional array with zeros.");
            while (!done)
            {
                Console.Write("Enter the first dimension: ");
                string a_str = Console.ReadLine();
                Console.Write("Enter the second dimension: ");
                string b_str = Console.ReadLine();
                Console.Write("Enter the third dimension: ");
                string c_str = Console.ReadLine();
                try
                {
                    a = Int32.Parse(a_str);
                    b = Int32.Parse(b_str);
                    c = Int32.Parse(c_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! One of the values you entered is not an integer. Try again!");
                    continue;
                }
                if (a <= 0 || b <= 0 || c <= 0)
                {
                    Console.WriteLine("Error! One of the values you entered is less than or equal to zero. Try again!");
                    continue;
                }
                else
                {
                    int[,,] threedim = new int[a, b, c]; // Three-dimensional array
                    Random rnd = new Random();
                    Console.Write("Random 3D-array: [");
                    for (int i=0; i<a; i++)
                    {
                        for (int j=0; j<b; j++)
                        {
                            for (int k=0; k<c; k++)
                            {
                                int num = rnd.Next(-1000, 1000);
                                threedim[i, j, k] = num;
                                if (i == a - 1 && j == b - 1 && k == c - 1)
                                {
                                    Console.WriteLine(num + "]");
                                } 
                                else
                                {
                                    Console.Write(num + ", ");
                                }                                
                            }
                        }
                    }
                    Console.Write("3D-array after processing: [");
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            for (int k = 0; k < c; k++)
                            {
                                if (threedim[i, j, k] < 0)
                                {
                                    threedim[i, j, k] = 0;
                                }
                                if (i == a - 1 && j == b - 1 && k == c - 1)
                                {
                                    Console.WriteLine(threedim[i, j, k] + "]");
                                } 
                                else
                                {
                                    Console.Write(threedim[i, j, k] + ", ");
                                }
                            }
                        }
                    }
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
