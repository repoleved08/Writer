using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SenderBus
{
    public interface ISenderBus
    {
        Task PublishMessage(object message, string queueTopic);
    }
}
