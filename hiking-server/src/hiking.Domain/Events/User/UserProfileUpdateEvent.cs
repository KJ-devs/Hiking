using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class UserProfileUpdatedEvent : DomainEvent
    {
        public Guid UserId { get; }

        public UserProfileUpdatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}