using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class ConcreteVisitorProduct : IVisitor
    {
        private readonly Dictionary<ISellable, decimal> ProductTransactions;

        public void visitTransaction(Transaction transaction)
        {
            ISellable product = transaction._product;
            ProductTransactions.Add(product, transaction._client.GetAppropriatePrice(transaction._product));
        }
    }
}
