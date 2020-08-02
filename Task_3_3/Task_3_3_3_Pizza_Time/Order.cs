using System;

namespace Task_3_3_3_Pizza_Time
{
    class Order
    {
        public event Action<Order> OnReady = delegate { };
        public string Customer { get; private set; }
        public IPizza Pizza { get; private set; }

        public Order(string id, IPizza pizza)
        {
            Customer = id;
            Pizza = pizza;
        }

        public void Ready()
        {
            OnReady(this);
        }
    }
}
