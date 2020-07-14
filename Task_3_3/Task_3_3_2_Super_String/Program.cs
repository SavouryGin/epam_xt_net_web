using System;
using System.Collections.Generic;

namespace Task_3_3_2_Super_String
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> samples = new List<string>
            {
                "asdfASDF",
                "фываФЫВАёЁ",
                "1234567890",
                ".,!? -:;",
                "asdf фыва 123!",
                " ",
                ".",
                "c",
                "с",
                "4"
            };

            Console.WriteLine("=== Super String Demо ===");

            foreach (string sample in samples)
            {
                Console.WriteLine("The sample '{0}' is {1}", sample, sample.IdentifyLanguage());
            }

            Console.ReadLine();
        }
    }
}
