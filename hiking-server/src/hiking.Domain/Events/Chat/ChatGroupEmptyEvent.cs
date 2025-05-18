
using Hiking.Domain.Common;


namespace Hiking.Domain.Events.Chat;

public class ChatGroupEmptyEvent : DomainEvent
{
    public Guid GroupId { get; }

    public ChatGroupEmptyEvent(Guid groupId)
    {
        GroupId = groupId;
    }
}