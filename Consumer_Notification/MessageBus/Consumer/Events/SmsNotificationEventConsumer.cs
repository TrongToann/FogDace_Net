using Consumer_Notification.Abstractions.Messages;
using Contract.IntegrationEvent;
using MediatR;

namespace Consumer_Notification.MessageBus.Consumer.Events
{
    public class SmsNotificationEventConsumer : Consumer<DomainEvent.SmsNotificationEvent>
    {
        
        public SmsNotificationEventConsumer(ISender sender) : base(sender)
        {
        }
    }
}
