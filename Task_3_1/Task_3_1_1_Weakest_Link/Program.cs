using System;
using System.Text;
using System.Collections.Generic;
using System.CodeDom;

namespace Task_3_1_1_Weakest_Link
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello! This program crosses out players one by one from the circle.");

            bool done = false;

            do
            {
                Console.WriteLine("---------------------------------------");
                Console.Write("The number of players: ");
                string firstInput = Console.ReadLine().Trim();

                bool success = int.TryParse(firstInput, out int number);
                if (!success)
                {
                    Console.WriteLine("You entered an incorrect value. Try again!");
                    continue;
                }

                if (number < 1)
                {
                    Console.WriteLine("The number of players cannot be less than one. Try again!");
                    continue;
                }
                else if (number == 1)
                {
                    Console.WriteLine("Only one player? Well, you crossed yourself out. Try again!");
                    continue;
                }

                Console.Write("The cross out number (type 0 for random): ");
                string secondInput = Console.ReadLine().Trim();

                success = int.TryParse(secondInput, out int toCrossOut);
                if (!success)
                {
                    Console.WriteLine("You entered an incorrect value. Try again!");
                    continue;
                }

                if (toCrossOut < 0)
                {
                    Console.WriteLine("You entered an incorrect value. Try again!");
                    continue;
                }
                else if (toCrossOut > number)
                {
                    Console.WriteLine("You entered a number that exceeds the number of players. Try again!");
                    continue;
                }
                else if (toCrossOut == 0)
                {
                    Random rand = new Random();
                    toCrossOut = rand.Next(1, number);

                }

                Console.WriteLine("The circle of {0} players is ready. \n" +
                    "Start crossing out every {1}-th person.", number, toCrossOut);
                
                // Do all the work
                DisplayResult(Counter(number, toCrossOut));
                
                Console.WriteLine("---------------------------------------");
                Console.Write("Type 'yes' if you want to continue or something else to break: ");
                string ans = Console.ReadLine().ToLower();

                if (ans == "yes" || ans == "y")
                {
                    continue;
                }
                else
                {
                    done = true;
                }

            } while (!done);

            Console.ReadKey();
        }

        /* The method creates an array of n natural numbers, 
         * crosses out every k-th element from this array
         * and retuns the the order in which elements were crossed out.
         */
        public static int[] Counter(int n, int k)
        {
            if (n <= 0 || k <= 0 || n < k)
            {
                throw new ArgumentException("One of the values you provided is incorrect. \n" +
                    " Сannot create the required array.");
            }

            // Initialize circle of players
            List<int> circle = new List<int>();

            for (int i = 0; i < n; i++)
            {
                circle.Add(i + 1);
            }

            // Handle the special cases
            if (k == 1)
            {
                return circle.ToArray();
            }
            else if (k == n)
            {
                circle.Reverse();
                return circle.ToArray();
            }

            int[] result = new int[n];
            int pos = 0;
            int toQuit = k - 1;
            

            // Start counting
            do
            {
                // Save crossed out player to the result array
                result[pos] = circle[toQuit];
                pos++;

                // Deleted this player from circle
                circle.Remove(circle[toQuit]);

                // Recalculate crossed out number
                toQuit += k - 1;

                while (circle.Count <= toQuit)
                {
                    toQuit -= circle.Count;
                }              

                if (circle.Count == 1)
                {
                    result[pos] = circle[0];
                    circle.Remove(circle[0]);
                }

            } while (circle.Count != 0);

            return result;
        }

        public static void DisplayResult(int[] order)
        {
            int remains = order.Length;
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < order.Length; i++)
            {
                remains--;
                Console.WriteLine("\t Round {0}. Crossed out {1}-th person. People left: {2}", i + 1, order[i], remains);
                res.Insert(0, order[i].ToString() + "-th ");
            }

            Console.WriteLine("Done! It's impossible to cross out more people.");
            Console.WriteLine("The final order: " + res);
        }
    }
}
