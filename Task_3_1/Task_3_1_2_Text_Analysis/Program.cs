using System;
using System.Collections.Generic;
using System.Text;

namespace Task_3_1_2_Text_Analysis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================================================\n" +
                              "***  \\(^_^)/  Hello, dear fashion magazine editor!  \\(^_^)/   ***\n" +
                              "*** This fancy program will check your text for originality.  ***\n" +
                              "=================================================================");

            bool done = false;

            do
            {
                // Request user text in parts
                string text = DialogWithEditor();

                if (text.Length <= 1)
                {
                    Console.WriteLine("The text you entered is too short. Try again!");
                    continue;
                }

                try
                {
                    Dictionary<string, int> result = new Dictionary<string, int>();
                    result = WordCounter(text);
                    DisplayResults(result);
                } 
                catch (Exception e)
                {
                    Console.Write(e.Message);
                    Console.WriteLine(" Try again!");
                    continue;
                }             

                Console.WriteLine("-------------------------------------------------------------");
                Console.Write("Type 'yes' if you want to continue or something else to break: ");
                string ans = Console.ReadLine().ToLower().Trim();

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

        /* The method takes a string as input, breaks it into words, 
         * counts the frequency of each word in the string, 
         * and returns a dictionary <word: int>.       
         */
        public static Dictionary<string, int> WordCounter(string input)
        {
            // Split text into separate words
            string[] words = input.Split(new[] { '.', ',', ' ', ';',
                    ':', '!', '?', '"', '(', ')', '-'}, StringSplitOptions.RemoveEmptyEntries);

            // Check for too short input
            if (words.Length <= 3)
            {
                throw new ArgumentException("It appears your text contains too few words to check for word frequency.");
            }

            // Initiate dictionary to save each word and its frequency
            Dictionary<string, int> wordDict = new Dictionary<string, int>();

            // Check every word in input
            foreach (string word in words)
            {
                // Skip articles, prepositions and other stop words
                if (StopWords.englishWords.Contains(word))
                {
                    continue;
                }

                // If the word is in the dictionary, increase its frequency
                if (wordDict.ContainsKey(word))
                {
                    wordDict[word] += 1;
                }
                else // Otherwise add this word to the dictionary as a new key
                {
                    wordDict.Add(word, 1);
                }
            }

            return wordDict;
        }

        public static void DisplayResults(Dictionary<string, int> result)
        {
            Dictionary<string, int> commonWords = new Dictionary<string, int>();

            // Scan the given dictionary
            foreach (string word in result.Keys)
            {
                // Skip rare words
                if (result[word] < 3)
                {
                    continue;
                }
                else // Add common words to a new dictionary
                {
                    commonWords.Add(word, result[word]);
                }
            }

            // Print the most common words to the console
            if (commonWords.Count < 1)
            {
                Console.WriteLine("----- Scanning the text -----");
                Console.WriteLine("Your text is quite original. Frequent repetitions of words are not found!\n" +
                    "Keep in mind that the program did not take into account the English articles, \n" +
                    "prepositions and other stop words.");
            }
            else
            {
                Console.WriteLine("----- Scanning the text -----");
                Console.WriteLine("The following words are repeated too often in your text: ");

                foreach (string word in commonWords.Keys)
                {
                    Console.WriteLine("\t {0} : {1} times", word, commonWords[word]);
                }

                Console.WriteLine("Try to replace these words with synonyms.");
            }
        }

        public static string DialogWithEditor()
        {
            StringBuilder input = new StringBuilder();
            bool endEntering = false;
            
            do
            {
                Console.WriteLine("\t--- Enter a part of your text, please: ---");

                string rawText = Console.ReadLine().ToLower().Trim();
                input.Append(rawText + " ");

                Console.WriteLine("\t--- Type 'yes' if you wish to add more parts: ---");
                string answer = Console.ReadLine().ToLower().Trim();

                if (answer == "yes" || answer == "y")
                {
                    continue;
                }
                else
                {
                    endEntering = true;
                }

            } while (!endEntering);

            return input.ToString();
        }
    }   
}
