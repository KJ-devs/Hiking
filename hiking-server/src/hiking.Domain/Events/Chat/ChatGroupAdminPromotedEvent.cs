using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;
public class ChatGroupAdminPromotedEvent : DomainEvent
{
    public Guid GroupId { get; }
    public Guid UserId { get; }

    public ChatGroupAdminPromotedEvent(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }
}