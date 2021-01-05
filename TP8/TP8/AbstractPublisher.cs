using System;
using System.Collections.Generic;
using System.Text;

namespace TP8
{
    public abstract class AbstractPublisher : IPublisher
    {
        public List<ISubscriber> Subscribers { get; set; }

        public AbstractPublisher()
        {
            Subscribers = new List<ISubscriber>();
        }

        public virtual void Attach(ISubscriber subscriber)
        {
            Subscribers.Add(subscriber);
        }

        public virtual void Detach(ISubscriber subscriber)
        {
            Subscribers.Remove(subscriber);
        }
    }
}
