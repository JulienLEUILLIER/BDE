using System;
using System.Collections.Generic;
using System.Text;
using TestsUnitaires.DataGenerator;
using TP8;

namespace TestsUnitaires.TransactionsTestsClasses
{
    internal class StubStock : IStockBehaviour
    {
        public Dictionary<Product, int> StockProduct { get; set; }
        private readonly StudentOfficeBuilder builder;

        public StubStock()
        {
            builder = new StudentOfficeBuilder();
            StockProduct = new Dictionary<Product, int>
            {
                { ProductGenerator.chips, 15 },
                { ProductGenerator.water, 15 },
                { ProductGenerator.beer, 15 }
            };
        }

        public void AddToStock(Order newOrder)
        {
            throw new NotImplementedException();
        }

        public void SellingOperations(decimal appropriatePrice, Order order)
        {
            
        }

        public void Notify(Product product)
        {
            throw new NotImplementedException();
        }

        public void Attach(ISubscriber publisher)
        {
            throw new NotImplementedException();
        }

        public void Detach(ISubscriber publisher)
        {
            throw new NotImplementedException();
        }
    }
}
