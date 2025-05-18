using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat.Message;
public class GroupMessageSentEvent : DomainEvent
{
    public Guid MessageId { get; }
    public Guid SenderId { get; }
    public Guid GroupId { get; }

    public GroupMessageSentEvent(Guid messageId, Guid senderId, Guid groupId)
    {
        MessageId = messageId;
        SenderId = senderId;
        GroupId = groupId;
    }
}