using System;
using System.Collections.Generic;
using System.Threading;

namespace Task_2_2_Game
{
    /* Classic car game. The player needs to drive his car (&) to overtake other racers (@).
     * Crushes reduce the number of lives.
     * Asterisk (*) gives extra life.
     * Hyphen (-) slow down.
     * If the number of lives drops to zero, the game ends.
     */
    class Program
    {
        // The structure Object models the atomic entities of the game
        struct Object
        {
            public int x;
            public int y;
            public char c;
            public ConsoleColor color;
        }

        // Display objects
        private static void PrintOnPosition(int x, int y,
            char c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        // Display messages
        private static void PrintStringOnPosition(int x, int y,
            string str, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write(str);
        }

        // Start game
        static void Main()
        {
            // Starting position
            double speed = 100.0;
            double acceleration = 0.5;
            int playfieldWidth = 5;
            int livesCount = 5;

            // Set console window size
            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = 30;

            // Initialize user car
            Object userCar = new Object
            {
                x = 2,
                y = Console.WindowHeight - 1,
                c = '&',
                color = ConsoleColor.Yellow
            };

            Random randomGenerator = new Random();

            List<Object> objects = new List<Object>();

            // Start movement
            while (true)
            {
                // Speed is constantly growing
                speed += acceleration;

                // Set max speed
                if (speed > 400)
                {
                    speed = 400;
                }

                // Generate track
                {
                    int chance = randomGenerator.Next(0, 100);
                    if (chance < 10)
                    {
                        // Extra life gem
                        objects.Add(new Object
                        {
                            color = ConsoleColor.Cyan,
                            c = '*',
                            x = randomGenerator.Next(0, playfieldWidth),
                            y = 0
                        });
                    }
                    else if (chance < 20)
                    {
                        // Obstacle
                        objects.Add(new Object
                        {
                            color = ConsoleColor.DarkGreen,
                            c = '-',
                            x = randomGenerator.Next(0, playfieldWidth),
                            y = 0
                        });
                    }
                    else
                    {
                        // Enemy car
                        objects.Add(new Object
                        {
                            color = ConsoleColor.DarkRed,
                            x = randomGenerator.Next(0, playfieldWidth),
                            y = 0,
                            c = '@'
                        });
                    }
                }

                // Keyboard control
                while (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (userCar.x - 1 >= 0)
                        {
                            userCar.x -= 1;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (userCar.x + 1 < playfieldWidth)
                        {
                            userCar.x += 1;
                        }
                    }
                }

                // Initialize new list of objects
                List<Object> newList = new List<Object>();
                
                // Did the car crash?               
                bool hitted = false;

                // Check if objects are in contact
                for (int i = 0; i < objects.Count; i++)
                {
                    Object oldCar = objects[i];
                    Object newObject = new Object();

                    newObject.x = oldCar.x;
                    newObject.y = oldCar.y + 1;
                    newObject.c = oldCar.c;
                    newObject.color = oldCar.color;

                    // Meet obstacle
                    if (newObject.c == '-' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        speed -= 20;
                    }
                    
                    // Meet life gem
                    if (newObject.c == '*' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        livesCount++;
                    }

                    // Meet other car
                    if (newObject.c == '@' && newObject.y == userCar.y && newObject.x == userCar.x)
                    {
                        hitted = true;
                        livesCount--;
                        speed += 50;

                        if (speed > 400)
                        {
                            speed = 400;
                        }

                        // Quit the game
                        if (livesCount <= 0)
                        {
                            PrintStringOnPosition(8, 10, "GAME OVER!!!", ConsoleColor.Red);
                            PrintStringOnPosition(8, 12, "Press [enter] to exit", ConsoleColor.Red);
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                    }

                    // Add objects to a new row
                    if (newObject.y < Console.WindowHeight)
                    {
                        newList.Add(newObject);
                    }
                }
                
                // Update list of objects
                objects = newList;
                Console.Clear();

                // If a collision occurs, the user car stops
                if (hitted)
                {
                    objects.Clear();
                    PrintOnPosition(userCar.x, userCar.y, 'X', ConsoleColor.Red);
                }
                else
                {
                    PrintOnPosition(userCar.x, userCar.y, userCar.c, userCar.color);
                }

                foreach (Object car in objects)
                {
                    PrintOnPosition(car.x, car.y, car.c, car.color);
                }

                // Draw info panel
                PrintStringOnPosition(8, 4, "Lives: " + livesCount, ConsoleColor.White);
                PrintStringOnPosition(8, 5, "Speed: " + speed, ConsoleColor.White);
                PrintStringOnPosition(8, 6, "Acceleration: " + acceleration, ConsoleColor.White);

                // Pause current thread
                Thread.Sleep((int)(600 - speed));
            }
        }
    }
}
