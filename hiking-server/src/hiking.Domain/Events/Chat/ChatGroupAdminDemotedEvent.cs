
using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;
public class ChatGroupAdminDemotedEvent : DomainEvent
{
    public Guid GroupId { get; }
    public Guid UserId { get; }

    public ChatGroupAdminDemotedEvent(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }
}