using System;
using System.Collections.Generic;

namespace Task_2_2_Adventure
{
    class Game
    {
        Location currentLocation;

        public bool isRunning = true;
        private bool _gameOver = false;

        private List<Item> inventory;

        public Game()
        {
            inventory = new List<Item>();

            Console.WriteLine("Привет, путешественник! Ты готов к фантастическому приключению?");
            Console.WriteLine("Нажми 'h' или 'help' для подсказки.");

            // Построить карту
            Location l1 = new Location("Вход в галерею", "Ты стоишь в самом начале длинной галереи," +
                "\nона не освещена, и ее конец скрыт во мраке." +
                "\nНа востоке от тебя старая дубовая дверь. " +
                "\nНезапертая и манящая.");

            Item rock = new Item("rock", true, "Зазубренный камень. Размером с кулак.");
            l1.addItem(rock);

            Location l2 = new Location("Конец галереи", "Вы дошел до конца длинного темного коридора. " +
                "\nОстается только путь назад.");

            Item window = new Item("window", false, "Небольшое стеклянное окно. Кажется, оно плотно закрыто.");
            l2.addItem(window);

            Location l3 = new Location("Маленький кабинет", "Тесный кабинет с огромным письменным столом, заваленным бумагами. " +
                "\nНаверняка они представляют какую-то ценность," +
                "\nно ты не можешь разобрать странный язык, на котором они написаны.");

            l1.addExit(new Exit(Exit.Directions.North, l2));
            l1.addExit(new Exit(Exit.Directions.East, l3));

            l2.addExit(new Exit(Exit.Directions.South, l1));

            l3.addExit(new Exit(Exit.Directions.West, l1));

            currentLocation = l1;
            showLocation();
        }

        public void showLocation()
        {
            Console.WriteLine("\n" + currentLocation.getTitle() + "\n");
            Console.WriteLine(currentLocation.getDescription());

            if (currentLocation.getInventory().Count > 0)
            {
                Console.WriteLine("\nКомната содержит: \n");

                for (int i = 0; i < currentLocation.getInventory().Count; i++)
                {
                    Console.WriteLine(currentLocation.getInventory()[i].Name);
                }
            }

            Console.WriteLine("\nДоступные направления: \n");

            foreach (Exit exit in currentLocation.getExits())
            {
                Console.WriteLine(exit.getDirection());
            }

            Console.WriteLine();
        }

        public void doAction(string command)
        {
            // Help command
            if (command == "help" || command == "h")
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("Добро пожаловать в текстовое приключение!");
                Console.WriteLine("'l' / 'look':        Показывает комнату, выходы и предметы.");
                Console.WriteLine("'Look at X':         Даёт информацию о предмете в инвентаре, \n                     X - имя предмета.");
                Console.WriteLine("'pick up X':         Попробовать добрать предмет, X - имя предмета.");
                Console.WriteLine("'use X':             Попробовать использовать предмет, X - имя предмета.");
                Console.WriteLine("'i' / 'inventory':   Позволяет просмотреть предметы в инвентаре.");
                Console.WriteLine("'q' / 'quit':        Выход из игры.");
                Console.WriteLine();
                Console.WriteLine("Команды можно вводить либо полностью, либо в сокращении \nнапример, 'North' или 'N'");
                Console.WriteLine("===========================================");
                return;
            }

            // Доступ к инвентарю игрока
            if (command == "inventory" || command == "i")
            {
                showInventory();
                Console.WriteLine();
                return;
            }

            // Подобрать предмет
            if (command.Length >= 7 && command.Substring(0, 7) == "pick up")
            {
                if (command == "pick up")
                {
                    Console.WriteLine("\nУточни, что ты хочешь взять.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) && currentLocation.getInventory().Exists(x => x.Useable == true))
                {
                    inventory.Add(currentLocation.takeItem(command.Substring(8)));
                    Console.WriteLine("\nТы подобрал " + command.Substring(8) + ".\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) && currentLocation.getInventory().Exists(x => x.Useable == false))
                {
                    Console.WriteLine("\nТы не можешь взять " + command.Substring(8) + ".\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\n" + command.Substring(8) + " не существует.\n");
                    return;
                }
            }

            // Осмотреться вокруг
            if (command == "look" || command == "l")
            {
                showLocation();
                if (currentLocation.getInventory().Count == 0)
                {
                    Console.WriteLine("В комнате нет ничего интересного.\n");
                }
                return;
            }

            if (command.Length >= 7 && command.Substring(0, 7) == "look at")
            {
                if (command == "look at")
                {
                    Console.WriteLine("\nУточни, на что ты хочешь рассмотреть подробнее.\n");
                    return;
                }
                if (currentLocation.getInventory().Exists(x => x.Name == command.Substring(8)) || inventory.Exists(x => x.Name == command.ToLower().Substring(8)))
                {
                    if (command.Substring(8).ToLower() == "rock")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("rock")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("window")).Description + "\n");
                        return;
                    }

                    if (command.Substring(8).ToLower() == "smashed window")
                    {
                        Console.WriteLine("\n" + currentLocation.getInventory().Find(x => x.Name.Contains("smashed window")).Description + "\n");
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nТакого предмета нет в комнате или инвентаре.\n");
                    return;
                }
            }

            // Использовать предмет
            if (command.Length >= 3 && command.Substring(0, 3) == "use")
            {
                if (command == "use")
                {
                    Console.WriteLine("\nУточни, что ты хочешь использовать.\n");
                    return;
                }
                if (inventory.Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    Console.WriteLine("\nИспользовать " + command.Substring(4) + "?\n");
                    string secondItem = Console.ReadLine();

                    if (currentLocation.getInventory().Exists(x => x.Name == secondItem))
                    {
                        if (secondItem == "window" && command.Substring(4) == "rock")
                        {
                            Item smashedWindow = new Item("smashed window", false, "Оконная рама с осколками стекла.");
                            currentLocation.addItem(smashedWindow);

                            foreach (Item item in currentLocation.getInventory())
                            {
                                if (item.Name.ToLower() == "window")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                                if (item.Name.ToLower() == "rock")
                                {
                                    currentLocation.removeItem(item);
                                    break;
                                }

                            }
                            Console.WriteLine("\nТы разбил окно.\n");
                            return;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Это невозможно сделать.");
                        return;
                    }
                }

                if (currentLocation.getInventory().Exists(x => x.Name == command.ToLower().Substring(4)))
                {
                    if (command.ToLower().Substring(4) == "window")
                    {
                        Console.WriteLine("\nОкно плотно закрыто и не поддаётся.\n");
                        return;
                    }
                    if (command.ToLower().Substring(4) == "smashed window")
                    {
                        Console.WriteLine("\nТебе удалось вылезти из окна! Победа!");
                        _gameOver = true;
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("\nНечего использовать.\n");
                    return;
                }
            }

            if (moveRoom(command))
                return;

            Console.WriteLine("\nНекорректная команда. Нужна помощь?\n");
        }

        private bool moveRoom(string command)
        {
            foreach (Exit exit in currentLocation.getExits())
            {
                if (command == exit.ToString().ToLower() || command == exit.getShortDirection().ToLower())
                {
                    currentLocation = exit.getLeadsTo();
                    Console.WriteLine("\nТы передвинул " + exit.ToString() + " к:\n");
                    showLocation();
                    return true;
                }
            }
            return false;
        }


        private void showInventory()
        {
            if (inventory.Count > 0)
            {
                Console.WriteLine("\nБыстро заглянув в рюззак, ты обнаружил следующее:\n");

                foreach (Item item in inventory)
                {
                    Console.WriteLine(item.Name);
                }
            }
            else
            {
                Console.WriteLine("\nТвой рюкзак пуст.\n");
            }
        }

        public void Update()
        {
            string currentCommand = Console.ReadLine().ToLower();

            // Моментально выйти из игры
            if (currentCommand == "quit" || currentCommand == "q")
            {
                isRunning = false;
                return;
            }


            if (!_gameOver)
            {
                // в противном случае, продолжаем обрабатывать команды
                doAction(currentCommand);
            }
            else
            {
                Console.WriteLine("\nНет. Пора уходить.\n");
            }
        }
    }
}
