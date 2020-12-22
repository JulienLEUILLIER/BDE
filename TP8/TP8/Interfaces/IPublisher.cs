using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public interface IPublisher
    {
        public void Attach(ISubscriber subscriber);
        public void Detach(ISubscriber subscriber);
        public void Notify(Product product);
    }
}
