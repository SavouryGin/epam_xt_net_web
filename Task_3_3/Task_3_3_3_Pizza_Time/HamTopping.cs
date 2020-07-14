namespace Task_3_3_3_Pizza_Time
{
	class HamTopping: Toppings
	{
		public HamTopping(IPizza pizza) : base(pizza) { }

		public override string Name => base.Name + " with ham";

		public override decimal Price => base.Price + .75M;

		public override int Time => base.Time + 3;
	}
}
