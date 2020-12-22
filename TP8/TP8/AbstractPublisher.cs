using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class AbstractPublisher : IPublisher
    {
        protected List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Attach(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void Detach(ISubscriber subscriber)
        {
            _subscribers.Remove(subscriber);
        }

        public virtual void Notify(Product product)
        {            
        }
    }
}
