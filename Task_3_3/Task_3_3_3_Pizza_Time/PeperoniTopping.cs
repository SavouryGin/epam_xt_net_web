namespace Task_3_3_3_Pizza_Time
{
	class PeperoniTopping: Toppings
	{
		public PeperoniTopping(IPizza pizza) : base(pizza) { }

		public override string Name => base.Name + " with pepperoni";

		public override decimal Price => base.Price + .75M;

		public override int Time => base.Time + 2;
	}
}
