using MassTransit;

namespace Contract.Abstraction.Message
{
    [ExcludeFromTopology]
    public interface IMessage : ICommand
    {
        public Guid Id { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
    }
}
