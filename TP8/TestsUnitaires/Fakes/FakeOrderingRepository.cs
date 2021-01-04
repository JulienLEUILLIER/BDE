using System.Collections.Generic;
using TP8;

namespace TestsUnitaires
{
    internal class FakeOrderingRepository : IOrderingRepository
    {
        public List<Order> OrdersPassed { get; set; }
        public FakeOrderingRepository()
        {
            OrdersPassed = new List<Order>();
        }

        public void SaveOrder(Order order)
        {
            OrdersPassed.Add(order);
        }
    }
}