using System;
using System.Collections.Generic;
using System.Globalization;

namespace Task_2_1_2_Custom_Paint
{
    class Program
    {
        // A dynamic list of all user-created polygons
        static List<Polygon> userList = new List<Polygon>();

        // Dialog with user
        static void Main(string[] args)
        {
            
            Console.WriteLine("Hello! This program will set the values of your polygons.");
            bool done = false;            

            do
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("What to do: " +
                    "\n \t 1: Add new polygon " +
                    "\n \t 2: Print polygons " +
                    "\n \t 3: Clear canvas " +
                    "\n \t 0: Exit");

                string action = Console.ReadLine();

                switch (action)
                {
                    case "1":
                        // Add a polygon
                        Console.WriteLine("What polygon do you want to add?");
                        Console.WriteLine("\t C - circle\n \t R - ring \n \t " +
                            "T - triangle\n \t S - square\n \t Re - rectangle");
                        string ans = Console.ReadLine();

                        switch (ans.ToLower())
                        {
                            case "c":
                                CreateCircle();                                
                                break;
                            case "r":
                                CreateRing();
                                break;
                            case "t":
                                CreateTriangle();
                                break;
                            case "s":
                                CreateSquare();
                                break;
                            case "re":
                                CreateRectangle();
                                break;
                            default:
                                Console.WriteLine("The value you entered is incorrect. Try again!");
                                break;
                        }
                        break;

                    case "2":
                        // Display information about all polygons in the console
                        Console.WriteLine("Your polygons: ");

                        foreach (Polygon p in userList)
                        {
                            Console.WriteLine("~ ~ ~ ~ ~ ~ ~ ~");
                            string inst = p.GetShape();
                            Console.WriteLine(inst + ": " + p.GetId());
                            Console.WriteLine("Area: {0:f2}", p.GetArea());
                        }

                        break;
                    case "3":
                        // Clear the list of polygons
                        Console.WriteLine("All data has been deleted!");
                        userList = new List<Polygon>();
                        break;
                    case "0":
                        // Finish work
                        Console.WriteLine("Goodbye!");
                        done = true;
                        break;
                    default:
                        Console.WriteLine("The value you entered is incorrect. Try again!");
                        break;
                }
            } while (!done);
            
            Console.ReadKey();            
        }       


        // Methods that validate inputs and create polygon classes
        public static bool CreateCircle()
        {
            bool isDone = false;
            int x;
            int y;
            int z;
            double r;

            Console.Write("Enter id: ");
            string id = Console.ReadLine();
            Console.Write("Enter X: ");
            string xInpit = Console.ReadLine();
            try
            {
                x = Int32.Parse(xInpit);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }
            Console.Write("Enter Y: ");
            string yInput = Console.ReadLine();
            try
            {
                y = Int32.Parse(yInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }
            Console.Write("Enter Z: ");
            string zInput = Console.ReadLine();
            try
            {
                z = Int32.Parse(zInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }
            Console.Write("Enter radius (coma separated number): ");
            string rInput = Console.ReadLine();
            try
            {
                r = double.Parse(rInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            if (r < 0)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Circle circle = new Circle(id, x, y, z, r);
            userList.Add(circle);
            Console.WriteLine("The circle '{0}' was successfully created", id);
            isDone = true;
            return isDone;
        }

        public static bool CreateRing()
        {
            bool isDone = false;
            int x;
            int y;
            int z;
            double r;
            double rInner;

            Console.Write("Enter id: ");
            string id = Console.ReadLine();
            Console.Write("Enter X: ");
            string xInpit = Console.ReadLine();

            try
            {
                x = Int32.Parse(xInpit);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter Y: ");
            string yInput = Console.ReadLine();

            try
            {
                y = Int32.Parse(yInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter Z: ");
            string zInput = Console.ReadLine();

            try
            {
                z = Int32.Parse(zInput);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter radius (coma separated number): ");
            string rInput = Console.ReadLine();

            try
            {
                r = double.Parse(rInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter inner radius (coma separated number): ");
            string rInnerInput = Console.ReadLine();

            try
            {
                rInner = double.Parse(rInnerInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            if (r < 0 || rInner < 0)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Ring ring = new Ring(id, x, y, z, r, rInner);
            userList.Add(ring);

            Console.WriteLine("The ring '{0}' was successfully created", id);
            isDone = true;
            return isDone;
        }

        public static bool CreateTriangle()
        {
            bool isDone = false;
            double a;
            double b;
            double c;

            Console.Write("Enter id: ");
            string id = Console.ReadLine();
            
            Console.Write("Enter the length of side A (coma separated number): ");
            string aInput = Console.ReadLine();
            try
            {
                a = double.Parse(aInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter the length of side B: ");
            string bInput = Console.ReadLine();
            try
            {
                b = double.Parse(bInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter the length of side C: ");
            string cInput = Console.ReadLine();
            try
            {
                c = double.Parse(cInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            if (a <= 0 || b <= 0 || c <= 0 ||
                (a + b > c && a + c > b && b + c > a))
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Triangle triangle = new Triangle(id, a, b, c);
            userList.Add(triangle);
            Console.WriteLine("The triangle '{0}' was successfully created", id);
            isDone = true;
            return isDone;
        }

        public static bool CreateSquare()
        {
            bool isDone = false;
            double a;

            Console.Write("Enter id: ");
            string id = Console.ReadLine();

            Console.Write("Enter the length of the side of the square (coma separated number): ");
            string aInput = Console.ReadLine();
            try
            {
                a = double.Parse(aInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }
            
            if (a <= 0)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Square square = new Square(id, a);
            userList.Add(square);
            Console.WriteLine("The square '{0}' was successfully created", id);
            isDone = true;
            return isDone;
        }

        public static bool CreateRectangle()
        {
            bool isDone = false;
            double a;
            double b;

            Console.Write("Enter id: ");
            string id = Console.ReadLine();

            Console.Write("Enter the length of side A (coma separated number): ");
            string aInput = Console.ReadLine();
            try
            {
                a = double.Parse(aInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Console.Write("Enter the length of side B: ");
            string bInput = Console.ReadLine();
            try
            {
                b = double.Parse(bInput, CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            if (a <= 0 || b <= 0)
            {
                Console.WriteLine("Error! The value you entered is incorrect. Try again!");
                return isDone;
            }

            Rectangle rectangle = new Rectangle(id, a, b);
            userList.Add(rectangle);
            Console.WriteLine("The rectangle '{0}' was successfully created", id);
            isDone = true;
            return isDone;
        }
    }    
}
