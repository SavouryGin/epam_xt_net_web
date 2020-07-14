namespace Task_3_3_3_Pizza_Time
{
	abstract class Toppings: IPizza
	{
		private IPizza pizza;

		public Toppings(IPizza pizza) => this.pizza = pizza;

		public virtual string Name => pizza.Name;

		public virtual decimal Price => pizza.Price;

		public virtual int Time => pizza.Time;
	}
}
