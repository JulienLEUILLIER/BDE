using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class OrderingRepository : IOrderingRepository
    {
        public List<Order> OrdersPassed { get; set; }

        public OrderingRepository()
        {
            OrdersPassed = new List<Order>();
        }

        public void SaveOrder(Order order)
        {
            OrdersPassed.Add(order);
        }
    }
}
