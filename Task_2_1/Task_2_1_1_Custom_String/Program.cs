using System;
using System.Text;
using Task_2_1_1_Custom_String_Library;

namespace Task_2_1_1_Custom_String
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== MyString Demo ===");
       
            // Using constructors
            MyString s0 = new MyString();
            MyString s1 = new MyString("Hello, World!");                        
            MyString s2 = new MyString(new char[] { 'C', '#', ' ', 'i', 's', ' ', 'c', 'o', 'o', 'l', '!' });
            MyString s3 = new MyString(new StringBuilder("I love programming!"));
            MyString s4 = s1;

            // Display new objects
            Console.WriteLine("s0: " + s0);
            Console.WriteLine("s1: " + s1);
            Console.WriteLine("s2: " + s2);
            Console.WriteLine("s3: " + s3);
            Console.WriteLine("s4: " + s4);

            // Using methods
            Console.WriteLine("=== Comparison method ===");
            Console.WriteLine("s1 equals s2? " + (s1 == s2));
            Console.WriteLine("s1 equals s4? " + s1.Equals(s4));

            Console.WriteLine("=== Concatenation method ===");
            Console.WriteLine("s1 + s2: " + s1 + s2);
            Console.WriteLine("s2 + s3: " + s2.Concat(s3));

            Console.WriteLine("=== Search method ===");
            Console.WriteLine("Symbol 'e' in s1: " + s1.FindSymbol('e'));
            Console.WriteLine("Substring 'cool' in s2: " + s2.FindSubstring("cool"));
            Console.WriteLine("Substring 'cool' in s3: " + s3.FindSubstring("cool"));

            Console.WriteLine("=== Multiplication method ===");
            Console.WriteLine("s1 * 3: " + (s1 * 3));
            Console.WriteLine("s3 * 2: " + (s3 * 2));
            Console.WriteLine("=== Slice method ===");

            Console.WriteLine("s1 from 0 to 5: " + s1.Slice(0, 5));
            Console.WriteLine("s2 from 3 to 10: " + s2.Slice(3, 10));

            // Using indexer
            Console.WriteLine("=== Indexer demo ===");
            Console.WriteLine("s3[0]: " + s3[0]);
            Console.WriteLine("s3[5]: " + s3[5]);

            Console.ReadKey();
        }
    }
}
