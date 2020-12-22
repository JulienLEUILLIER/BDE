using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface ISubscriber
    {
        public void Update(IPublisher publisher, KeyValuePair<Product, int> kvp);
    }
}
