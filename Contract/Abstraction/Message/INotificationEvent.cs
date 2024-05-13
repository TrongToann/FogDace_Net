using MassTransit;

namespace Contract.Abstraction.Message
{
    [ExcludeFromTopology]
    public interface INotificationEvent : IMessage
    {
        
    }
}
