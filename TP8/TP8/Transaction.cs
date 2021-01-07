using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public class Transaction : IVisitable
    {
        public Order _order { get; private set; }

        public ISellable _product { get; private set; }
        public Client _client { get; private set; }

        public decimal price { get; private set; }

        public Transaction(ISellable sellable, int quantity, Client client)
        {
            _product = sellable;
            _order = new Order(_product, quantity);
            _client = client;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.visitTransaction(this);
        }
    }
}
