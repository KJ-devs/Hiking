using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;

public class ChatGroupCreatedEvent : DomainEvent
{
    public Guid GroupId { get; }
    public Guid CreatorId { get; }

    public ChatGroupCreatedEvent(Guid groupId, Guid creatorId)
    {
        GroupId = groupId;
        CreatorId = creatorId;
    }
}