using System.Collections.Generic;

namespace TP8
{
    public interface IPublisher
    {
        List<ISubscriber> Subscribers { get; set; }
    }
}