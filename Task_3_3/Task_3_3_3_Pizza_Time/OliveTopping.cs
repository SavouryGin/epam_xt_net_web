namespace Task_3_3_3_Pizza_Time
{
	class OliveTopping: Toppings
	{
		public OliveTopping(IPizza pizza) : base(pizza) { }

		public override string Name => base.Name + " with olives";

		public override decimal Price => base.Price + .75M;

		public override int Time => base.Time + 4;
	}
}
