using System;

namespace Task_1_1_6_Font_adjustment
{
    class Program
    {
        [Flags]
        public enum Adjustments
        {
            None = 0,
            Bold = 1,
            Italic = 2,
            Underline = 4
        }
        static void Main(string[] args)
        {
            bool done = false;
            Console.ForegroundColor = ConsoleColor.Green; // Font Green
            Console.WriteLine("Hello! This program will set your font adjustment.");
            Adjustments c = Adjustments.None;
            Console.WriteLine("Current font adjustment: " + c.ToString());
            while (!done)
            {
                
                Console.WriteLine("Enter a value: \n \t 1: Bold \n \t 2: Italic " +
                    "\n \t 3: Underline \n \t 0: Clear adjustment");
                string v = Console.ReadLine();

                if (v == "1")
                {
                    c = c | Adjustments.Bold;
                } else if (v == "2") 
                {
                    c = c | Adjustments.Italic;
                } else if (v == "3")
                {
                    c = c | Adjustments.Underline;
                } else if (v == "0")
                {
                    c = Adjustments.None;
                }          
                else
                {
                    Console.WriteLine("The value you entered is incorrect. Try again!");
                }
                Console.WriteLine("Your current font adjustment: " + c.ToString());

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
                Console.WriteLine("Press any key to exit the program.");
                Console.ReadKey();
            }
        }
    }
}
