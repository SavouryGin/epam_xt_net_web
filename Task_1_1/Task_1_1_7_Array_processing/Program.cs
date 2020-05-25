using System;

namespace Task_1_1_7_Array_processing
{
    class Program
    {
        // Bubble Sort Algorithm
        public static void ArraySort(int[] nums)
        {
            int temp;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int len;
            bool done = false;
            Console.WriteLine("Hello! This program will sort the array \n" +
                "and find its maximum and minimum elements.");
            while (!done)
            {
                Console.Write("Enter the length of your array: ");
                string len_str = Console.ReadLine();
                
                try
                {
                    len = Int32.Parse(len_str);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error! The value you entered is not an integer. Try again!");
                    continue;
                }
                if (len < 1)
                {
                    Console.WriteLine("Error! The value you entered is less than one. Try again!");
                    continue;
                }
                else
                {
                    int[] my_array = new int[len];
                    Random rnd = new Random();
                    for (int i = 0; i < len; i++)
                    {
                        int num = rnd.Next(-1000,1000);
                        my_array[i] = num;
                    }
                    Console.Write("Random array: [");
                    for (int i = 0; i < len; i++)
                    {                        
                        if (i == len - 1)
                        {
                            Console.WriteLine(my_array[i] + "]");
                        } else
                        {
                            Console.Write(my_array[i] + ", ");
                        }
                        
                    }
                    ArraySort(my_array);
                    Console.Write("Sorted array: [");
                    for (int i = 0; i < len; i++)
                    {
                        if (i == len - 1)
                        {
                            Console.WriteLine(my_array[i] + "]");
                        }
                        else
                        {
                            Console.Write(my_array[i] + ", ");
                        }

                    }
                    Console.WriteLine("Min element: " + my_array[0]);
                    Console.WriteLine("Max element: " + my_array[len-1]);
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
}
