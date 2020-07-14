using System;
using System.Collections.Generic;

namespace Task_3_3_3_Pizza_Time
{
    internal class Customer
    {
        private int id;
        private List<IPizza> pizzas;

        public Customer(int id)
        {
            this.Id = id;
            pizzas = new List<IPizza>();
        }

        public int Id { get => id; set => id = value; }

        public void AddToOrder(IPizza pizza)
        {
            pizzas.Add(pizza);
        }
        
        public void PrindOrder()
        {
            decimal total = 0;
            int time = 0;
            foreach(IPizza pizza in pizzas)
            {
                PizzaFactory.PrintReceipt(pizza);
                total += pizza.Price;
                time += pizza.Time;
            }

            Console.WriteLine("Please wait for {0} minutes", time);
            Console.WriteLine("=== Total: {0} ===", total);
        }       
        
    }
}
