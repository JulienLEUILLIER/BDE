using System.Collections.Generic;

namespace TP8
{
    public interface IOrderingRepository
    {
        List<Order> OrdersPassed { get; set; }
        void SaveOrder(Order order);
    }
}