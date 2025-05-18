using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat.Message;

public class MessageReadEvent : DomainEvent
{
    public Guid MessageId { get; }
    public Guid UserId { get; }

    public MessageReadEvent(Guid messageId, Guid userId)
    {
        MessageId = messageId;
        UserId = userId;
    }
}