using System;

namespace Task_1_1_5_Sum_of_numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            Console.WriteLine("Multiples of three or five from 1 to 1000: ");
            for (int i = 1; i <= 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {                    
                    sum += i;
                    if (i == 1000)
                    {
                        Console.WriteLine(i + ".");
                    } else
                    {
                        Console.Write(i + ", ");
                    }                 
                }
                else
                {
                    continue;
                }
            }
            Console.WriteLine("The sum of these numbers is " + sum);
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
