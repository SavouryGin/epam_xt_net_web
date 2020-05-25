using System;

namespace Task_1_2_3_Lowercase
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            Console.WriteLine("Hello! This program will count all words that begin with a lowercase letter.");

            while (!done)
            {
                Console.WriteLine("Enter a sentence: ");
                string text = Console.ReadLine();
                if (text.Length < 1)
                {
                    Console.WriteLine("You have entered an empty string.");
                    continue;
                }
                
                // Split sentence into separate words
                var words = text.Split(new[] { '.', ',', ' ', ';', ':', '!', '?', '"', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                int counter = 0;
                foreach (string word in words)
                {
                    if (Char.IsLower(word[0]))
                    {
                        counter++;
                        Console.WriteLine("\t '" + word + "' *");
                    } 
                    else
                    {
                        Console.WriteLine("\t '" + word + "'");
                    }                   
                    
                }

                Console.WriteLine("In your sentence {0} words begin with a lowercase letter.", counter);

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
