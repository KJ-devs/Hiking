
using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;

public class ChatGroupMemberAddedEvent : DomainEvent
{
    public Guid GroupId { get; }
    public Guid UserId { get; }

    public ChatGroupMemberAddedEvent(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }
}