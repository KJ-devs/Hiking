using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat.Message;
public class MessageDeliveredEvent : DomainEvent
{
    public Guid MessageId { get; }

    public MessageDeliveredEvent(Guid messageId)
    {
        MessageId = messageId;
    }
}