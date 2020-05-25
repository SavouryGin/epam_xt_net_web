using System;

namespace Task_1_1_1_Rectangle
{
    class Rectangle
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            bool done = false;
            Console.WriteLine("Hello! This program will calculate the area of your rectangle.");
            while (!done)
            {
                Console.WriteLine("Enter the length of side a: ");
                string a_str = Console.ReadLine();
                Console.WriteLine("Enter the length of side b: ");
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
                    Console.WriteLine("So, your rectangle is {0} m high and {1} m wide.", a, b);
                    int s = a * b;
                    Console.WriteLine("The area of this rectangle is {0} square meters.", s);
                    done = true;
                    
                }
            }
            Console.WriteLine("Press any key to exit the program.");
            Console.ReadKey();
        }
    }
}
