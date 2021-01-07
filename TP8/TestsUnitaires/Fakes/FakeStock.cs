using System;
using System.Collections.Generic;
using System.Text;
using TP8;

namespace TestsUnitaires.Fakes
{
    internal class FakeStock : AbstractPublisher, IStockBehaviour
    {
        public Dictionary<Product, int> StockProduct { get; set; }
        public FakeStock()
        {
            StockProduct = new Dictionary<Product, int>();
        }
        public void AddToStock(Order newOrder)
        {
            StockProduct.Add(newOrder._product, newOrder._quantity);
            SellingOperations(newOrder._product.MemberPrice, newOrder);
        }

        public void Notify(Product product)
        {
            foreach (var subscriber in Subscribers)
            {
                subscriber.Update(product);
            }
        }

        public void SellingOperations(decimal appropriatePrice, Order order)
        {
            Notify(order._product);
        }
    }
}
