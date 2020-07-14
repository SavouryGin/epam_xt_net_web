using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3_3_1_Super_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray1 = new int[] { 1, 1, 2, 2, 3, 3, 3, 4, 5, 6, 6, 7, 8 };
            List<double> testArray2 = new List<double> { 0.1, 3.42, 4.6, 5.11, 6.02, 12.22, 0.2 };
            List<string> testArray3 = new List<string> { "A", "B", "C", "D", "E", "C" };

            Console.WriteLine("\tTest collections:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("\tintArray: ");
            foreach (int num in testArray1) Console.Write(num + "  ");
            Console.WriteLine();

            Console.WriteLine("\tdoubleList: ");
            foreach (double num in testArray2) Console.Write(num + "  ");
            Console.WriteLine();

            Console.WriteLine("\tstringList: ");
            foreach (string s in testArray3) Console.Write(s + "  ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\t1. ProcessColl<T>() method: \n");
            int[] res1 = testArray1.ProcessColl(n => (n * n)).ToArray();
            double[] res2 = testArray2.ProcessColl(n => (n - 1)).ToArray();
            string[] res3 = testArray3.ProcessColl(s => (s + "?")).ToArray();

            Console.WriteLine("Get a square of each element in intArray: ");
            foreach (int num in res1) Console.Write(num + "  ");
            Console.WriteLine("\n");

            Console.WriteLine("Subtract 1 from each element in doubleList: ");
            foreach (double num in res2) Console.Write(num + "  ");
            Console.WriteLine("\n");

            Console.WriteLine("Add '?' sign to each element in stringList: ");
            foreach (string s in res3) Console.Write(s + "  ");
            Console.WriteLine();
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\t2. FindSum() method: \n");
            Console.WriteLine("The sum of all elements in the intArray = {0}", testArray1.FindSumOfColl());
            Console.WriteLine("The sum of all elements in the doubleList = {0:f2}", testArray2.FindSumOfColl());
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\t3. FindAverage() method: \n");
            Console.WriteLine("The average value in the intArray = {0:f2}", testArray1.FindAverageOfColl());
            Console.WriteLine("The average value in the doubleList = {0:f2}", testArray2.FindAverageOfColl());
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\t4. FindFrequent<T>() method: \n");
            Console.WriteLine("Most frequent element in the intArray: {0}", testArray1.FindFrequent());
            Console.WriteLine("Most frequent element in the doubleList: {0}", testArray2.FindFrequent());
            Console.WriteLine("Most frequent element in the stringList: {0}", testArray3.FindFrequent());
            Console.WriteLine("------------------------------------");

            Console.ReadKey();
        }
    }
}
