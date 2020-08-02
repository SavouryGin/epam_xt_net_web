using System;
using System.Collections.Generic;

namespace Task_3_3_3_Pizza_Time
{
    internal class Customer
    {
        private int id;
        private List<IPizza> pizzas;
        private Order order;

        public Customer(int id)
        {
            this.Id = id;
            pizzas = new List<IPizza>();
        }

        public int Id { get => id; set => id = value; }

        public void MakeOrder(IPizza pizza)
        {
            Console.WriteLine($"Customer #{id}: I want {pizza.Name}");
            order = new Order(id.ToString(), pizza);
            order.OnReady += TakePizza;
            PizzaFactory.ProcessOrder(order);
        }

        public void TakePizza(Order order)
        {
            Console.WriteLine($"Customer #{id}: order received!");
            order.OnReady -= TakePizza;
        }

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

            Console.WriteLine("Thanks for waiting {0} minutes", time);
            Console.WriteLine("=== Total: {0} ===", total);
        }       
        
    }
}
