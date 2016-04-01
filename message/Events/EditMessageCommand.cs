using Prism.Events;
using message.Data;

namespace message.Events
{
    public class EditMessageCommand : PubSubEvent<Message> { }
}
