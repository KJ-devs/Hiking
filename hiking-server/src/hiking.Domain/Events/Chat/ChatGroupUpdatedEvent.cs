
using Hiking.Domain.Common;
namespace Hiking.Domain.Events.Chat;

public class ChatGroupUpdatedEvent : DomainEvent
{
    public Guid GroupId { get; }

    public ChatGroupUpdatedEvent(Guid groupId)
    {
        GroupId = groupId;
    }
}