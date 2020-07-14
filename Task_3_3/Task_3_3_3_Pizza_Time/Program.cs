using System;
using System.Collections.Generic;

namespace Task_3_3_3_Pizza_Time
{
	/// <summary>
	/// The main class to set up tests and demo the final product.
	/// Our pizzeria can do the following:
	/// - Allow the customers to enter in if they want a large or extra large pizza. 
	/// - Customers can also choose to have 1, 2 or 3 toppings. 
	/// - Calculate the cost of the pizza and the two taxes (provincial and federal).
	/// - Display the cost of the pizza, each tax and the total cost.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{

			Console.WriteLine("=== Pizzeria Demo ===");
			Console.WriteLine();

			Customer first = new Customer(124);
			// Ask the factory for a pizza. Based on the size, get the right object back
			IPizza pizza1 = PizzaFactory.OrderPizza(PizzaSizes.Large);
			// Add toppings to the pizza
			pizza1 = PizzaFactory.AddTopping(pizza1, PizzaToppings.Ham);

			IPizza pizza2 = PizzaFactory.OrderPizza(PizzaSizes.Large);
			pizza2 = PizzaFactory.AddTopping(pizza2, PizzaToppings.Olives);
			pizza2 = PizzaFactory.AddTopping(pizza2, PizzaToppings.Pepperoni);

			// Add pizzas to cusmomers order
			first.AddToOrder(pizza1);
			first.AddToOrder(pizza2);

			Customer second = new Customer(125);
			IPizza pizza3 = PizzaFactory.OrderPizza(PizzaSizes.ExtraLarge);
			pizza3 = PizzaFactory.AddTopping(pizza3, PizzaToppings.Ham);
			pizza3 = PizzaFactory.AddTopping(pizza3, PizzaToppings.Olives);
			pizza3 = PizzaFactory.AddTopping(pizza3, PizzaToppings.Pepperoni);
			IPizza pizza4 = PizzaFactory.OrderPizza(PizzaSizes.Large);

			second.AddToOrder(pizza3);
			second.AddToOrder(pizza4);

			// Print all receipts
			Console.WriteLine("The customer # {0} ordered:", first.Id);
			first.PrindOrder();
			Console.WriteLine();
			Console.WriteLine("The customer # {0} ordered:", second.Id);
			second.PrindOrder();

			Console.ReadKey();
		}
	}	
}
