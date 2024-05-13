using Consumer_Notification.MessageBus.Consumer.Events;
using Contract.Abstraction.Message;
using Contract.Abstraction.Shared;
using Contract.IntegrationEvent;

namespace Consumer_Notification.UseCase.Events
{
    public class SendSmsEventConsumerHandler : ICommandHandler<DomainEvent.SmsNotificationEvent>
    {
        private readonly ILogger _logger;

        public SendSmsEventConsumerHandler(ILogger<SmsNotificationEventConsumer> logger)
        {
            _logger = logger;
        }

        public async Task<Result> Handle(DomainEvent.SmsNotificationEvent request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Message received : {message}", request);
            return Result.Success();
        }
    }
}
