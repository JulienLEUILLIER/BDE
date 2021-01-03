using System.Collections.Generic;
using TP8;

namespace TestsUnitaires
{
    internal class InMemoryOrderingRepository : IOrderingRepository
    {
        public List<Order> OrdersPassed { get; set; }
        public InMemoryOrderingRepository()
        {
            OrdersPassed = new List<Order>();
        }

        public void SaveOrder(Order order)
        {
            OrdersPassed.Add(order);
        }
    }
}