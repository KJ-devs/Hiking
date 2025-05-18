
using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;

public class ChatGroupMemberRemovedEvent : DomainEvent
{
    public Guid GroupId { get; }
    public Guid UserId { get; }

    public ChatGroupMemberRemovedEvent(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }
}