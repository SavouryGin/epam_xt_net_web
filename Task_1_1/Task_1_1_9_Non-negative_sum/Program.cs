using System;

namespace Task_1_1_9_Non_negative_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int len;
            bool done = false;
            Console.WriteLine("Hello! This program will calculate the sum \n" +
                "of all non-negative elements of the array.");
            while (!done)
            {
                Console.Write("Enter the length of your array: ");
                string len_str = Console.ReadLine();

                try
                {
                    len = Int32.Parse(len_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! The value you entered is not an integer. Try again!");
                    continue;
                }
                if (len < 1)
                {
                    Console.WriteLine("Error! The value you entered is less than one. Try again!");
                    continue;
                }
                else
                {
                    int[] my_array = new int[len];
                    Random rnd = new Random();
                    for (int i = 0; i < len; i++)
                    {
                        int num = rnd.Next(-1000, 1000);
                        my_array[i] = num;
                    }
                    int sum = 0;
                    Console.Write("Random array: [");
                    for (int i = 0; i < len; i++)
                    {
                        if (my_array[i] >= 0)
                        {
                            sum += my_array[i];
                        }
                        if (i == len - 1)
                        {
                            Console.WriteLine(my_array[i] + "]");
                        }
                        else
                        {
                            Console.Write(my_array[i] + ", ");
                        }
                    }
                    Console.WriteLine("The sum of all non-negative elements of the array is " + sum);
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
}
