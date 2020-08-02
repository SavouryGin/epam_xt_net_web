using System;
using System.Threading;

namespace Task_3_3_3_Pizza_Time
{
    static class PizzaFactory
	{

		private static decimal localTax = .6M;
		private static decimal federalTax = .7M;

		public static IPizza OrderPizza(PizzaSizes size)
		{

			switch (size)
			{
				case PizzaSizes.Large:
					return new LargePizza();

				case PizzaSizes.ExtraLarge:
					return new ExtraLargePizza();

				default:
					return null;
			}
		}

		public static IPizza AddTopping(IPizza pizza, PizzaToppings topping)
		{
			switch (topping)
			{
				case PizzaToppings.Pepperoni:
					return new PeperoniTopping(pizza);

				case PizzaToppings.Ham:
					return new HamTopping(pizza);

				case PizzaToppings.Olives:
					return new OliveTopping(pizza);

				default:
					return pizza;
			}
		}

		public static void PrintReceipt(IPizza pizza)
		{
			Console.WriteLine("Pizza: " + pizza.Name);
			Console.WriteLine("\tPreparing time: {0} min", pizza.Time);
			Console.WriteLine("\tSub-Total: " + pizza.Price);
			Console.WriteLine("\tAfter Federal Tax: " + (pizza.Price + federalTax));
			Console.WriteLine("\tAfter Local Tax: " + (pizza.Price + localTax));
			Console.WriteLine("\tTotal for pizza: " + (pizza.Price + localTax + federalTax));
		}

		public static void ProcessOrder(Order order)
		{
			Console.WriteLine("Pizzeria: Please wait. Processing your order ...");
			MakePizza(order);
		}

		public static void MakePizza(Order order)
		{
			Thread.Sleep(2000);
			Console.WriteLine($"Pizzeria: Dear Customer #{order.Customer}, your {order.Pizza.Name} is ready!");
			order.Ready();
		}
	}
}
