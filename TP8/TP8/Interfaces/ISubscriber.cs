using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface ISubscriber
    {
        public void Update(Product product);

        void SellProduct(Client client, Order order);
    }
}
