using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat.Message;
public class PrivateMessageSentEvent : DomainEvent
{
    public Guid MessageId { get; }
    public Guid SenderId { get; }
    public Guid RecipientId { get; }

    public PrivateMessageSentEvent(Guid messageId, Guid senderId, Guid recipientId)
    {
        MessageId = messageId;
        SenderId = senderId;
        RecipientId = recipientId;
    }
}