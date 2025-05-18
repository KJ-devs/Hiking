using Hiking.Domain.Common;
using Hiking.Domain.ValueObjects;

namespace Hiking.Domain.Events
{
    
    public class UserStatusChangedEvent : DomainEvent
    {
        public Guid UserId { get; }
        public UserStatus Status { get; }

        public UserStatusChangedEvent(Guid userId, UserStatus status)
        {
            UserId = userId;
            Status = status;
        }
    }
}