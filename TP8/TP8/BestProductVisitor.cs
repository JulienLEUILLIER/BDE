using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP8
{
    public class BestProductVisitor : IVisitor
    {
        public readonly Dictionary<ISellable, decimal> ProductTransactions;

        public BestProductVisitor()
        {
            ProductTransactions = new Dictionary<ISellable, decimal>(); 
        }

        private ISellable GetSellableInDictionary(string name)
        {
            return ProductTransactions.FirstOrDefault(kvp => kvp.Key._name.ToUpper().Equals(name.ToUpper())).Key;
        }
        public void visitTransaction(Transaction transaction)
        {
            ISellable product = transaction._product;
            ISellable checkedproduct = GetSellableInDictionary(transaction._product._name);
            decimal price = transaction._client.GetAppropriatePrice(transaction._product);
            int quantity = transaction._order._quantity;

            if (checkedproduct == null)
            {
                ProductTransactions.Add(product, price * quantity);
            }
            else
            {
                ProductTransactions[checkedproduct] += price * quantity;
            }
        }

        public ISellable GetBestproduct()
        {
            return ProductTransactions.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
        }

        public void DisplayBestproduct()
        {
            ISellable bestproduct = GetBestproduct();
            Console.WriteLine($"Best product is {bestproduct} which has made {ProductTransactions[bestproduct]} dollars.");
        }
    }
}
