using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1_2_4_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool done = false;
            Console.WriteLine("Hello! This program will capitalize your sentences.");

            while (!done)
            {
                Console.WriteLine("Enter a sentence: ");
                string text = Console.ReadLine();
                if (text.Length < 1)
                {
                    Console.WriteLine("You have entered an empty string.");
                    continue;
                }


                // Split input into separate sentences                
                var input = text.Split(new[] { '.', '!', '?'}, StringSplitOptions.RemoveEmptyEntries);

                // Save end of sentence signs
                List<char> marks = new List<char>();
                foreach (char c in text)
                {
                    if (c == '.' || c == '!' || c == '?')
                    {
                        marks.Add(c);
                    }
                }

                // Check whether the input contains end-of-sentence signs
                if (marks.Count == 0)
                {
                    Console.WriteLine("Your input is not a sentence. Try again!");
                    continue;
                }

                string result = "";
                for (int i = 0; i < input.Length; i++)
                {
                    // Trim the spaces around the sentence
                    string sentence = input[i].Trim();
                    // 
                    if (char.IsLetter(sentence[0])) 
                    {
                        // Capitalize the first letter
                        string capitalize = sentence.First().ToString().ToUpper() + sentence.Substring(1);
                        // Add a punctuation mark and one space at the end of the sentence
                        string to_add = capitalize + marks[i] + " ";
                        // Add sentence to the final text
                        result += to_add;
                    }
                    else
                    {
                        continue;
                    }                    
                }

                Console.WriteLine("Capitalized text: ");
                Console.WriteLine(result);

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
