using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IStockBehaviour
    {
        void AddToStock(Order newOrder);
        void SellingOperations(decimal appropriatePrice, Order order);
        void Notify(Product product);
        void Attach(ISubscriber publisher);
        void Detach(ISubscriber publisher);
    }
}
