using System;
using My_Dynamic_Array;

namespace Task_3_2_Dynamic_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t=== MyArray Demo ===");

            // Using different constructors
            MyArray<int> intArray1 = new MyArray<int>();
            MyArray<int> intArray2 = new MyArray<int>(100);
            int[] temp = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            MyArray<int> intArray3 = new MyArray<int>(temp);
            MyArray<string> stringArray = new MyArray<string> {"String 1", "String 2", "String 3"};
            TestClass class1 = new TestClass("TClass-1");
            TestClass class2 = new TestClass("TClass-2");
            TestClass class3 = new TestClass("TClass-3");
            MyArray<object> classArray = new MyArray<object> { class1, class2, class3 };

            Console.WriteLine("\t1. Testing constructors:");
            Console.WriteLine("Empty Int Array: [{0}]; Length: {1}; Capacity: {2}", intArray1, intArray1.Len, intArray1.Capacity);
            Console.WriteLine("Empty Int Array with custom capacity: [{0}]; Length: {1}; Capacity: {2}", intArray2, intArray2.Len, intArray2.Capacity);
            Console.WriteLine("Integer Array: [{0}]; Length: {1}; Capacity: {2}", intArray3, intArray3.Len, intArray3.Capacity);
            Console.WriteLine("String Array: [{0}]; Length: {1}; Capacity: {2}", stringArray, stringArray.Len, stringArray.Capacity);
            Console.WriteLine("Class Array: [{0}]; Length: {1}; Capacity: {2}", classArray, classArray.Len, classArray.Capacity);

            // Using methods
            intArray1.Add(999);
            intArray3.AddRange(temp);
            string[] tempString = new string[] { "String 4", "String 5", "String 6" };
            stringArray.AddRange(tempString);
            classArray.Remove(class2);
            

            Console.WriteLine("\t2. Testing Methods:");
            Console.WriteLine("Empty Int Array afte adding one element: [{0}]; Length: {1}; Capacity: {2}", intArray1, intArray1.Len, intArray1.Capacity);
            Console.WriteLine("Integer Array after adding an array: [{0}]; Length: {1}; Capacity: {2}", intArray3, intArray3.Len, intArray3.Capacity);
            Console.WriteLine("String Array after adding an array [{0}]; Length: {1}; Capacity: {2}", stringArray, stringArray.Len, stringArray.Capacity);
            Console.WriteLine("Class Array after removing second class: [{0}]; Length: {1}; Capacity: {2}", classArray, classArray.Len, classArray.Capacity);

            classArray.Insert(2, class2);
            Console.WriteLine("Class Array after inserting second class to the third position: [{0}]; Length: {1}; Capacity: {2}", classArray, classArray.Len, classArray.Capacity);
            Console.WriteLine("Is Integer Array contauns 8? - {0}", intArray3.Contains(8));
            Console.WriteLine("Is Integer Array contauns 0? - {0}", intArray3.Contains(0));


            Console.WriteLine("\t3. Testing indexer and foreach:");
            Console.WriteLine("Item with index 0 in String Array is: {0}", stringArray[0]);
            Console.WriteLine("Item with index 2 in String Array is: {0}", stringArray[2]);
            Console.WriteLine("Item with index -1 in String Array is: {0}", stringArray[-1]);
            Console.WriteLine("Item with index -5 in String Array is: {0}", stringArray[-5]);
            Console.WriteLine("Get the square of each number in Integer Array:");
            foreach (int num in intArray3)
            {
                Console.Write(num*num + " ");
            }
            Console.WriteLine();


            // Using MyCycledDynamicArray
            MyCycledDynamicArray<int> cycledArray = new MyCycledDynamicArray<int> { 1, 2, 3, 4, 5};

            // NB! Endless cycle
            Console.WriteLine("\t4. Testing Cycled Array: ");
            int c = 0;
            foreach (int num in cycledArray)
            {
                Console.Write(num + " ");
                c++;
                if (c > 100)
                {
                    Console.WriteLine("...");
                    break;
                }

            }

            Console.ReadKey();            
        }
    }

    class TestClass
    {
        public string className;
        public TestClass(string name) => className = name;

        public override string ToString() => className;

    }
}
