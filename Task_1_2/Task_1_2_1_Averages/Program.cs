using System;

namespace Task_1_2_1_Averages
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            Console.WriteLine("Hello! This program calculates the average word length in a sentence.");

            while (!done)
            {
                Console.WriteLine("Enter a sentence: ");
                string text = Console.ReadLine();
                if (text.Length < 1)
                {
                    Console.WriteLine("You have entered an empty string.");
                    continue;
                }
                double sum = 0;  
                // Split sentence into separate words
                var words = text.Split(new[] { '.', ',', ' ', ';', ':', '!', '?','"','(',')'}, StringSplitOptions.RemoveEmptyEntries);
                foreach (string word in words)
                {
                    Console.WriteLine("\t" + word + " [" + word.Length + "]");
                    sum += (double)word.Length;
                }
                double avg = sum / words.Length; // The result will be fractional
                Console.WriteLine("Average word length in this sentence is {0:#.##}", avg);
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
