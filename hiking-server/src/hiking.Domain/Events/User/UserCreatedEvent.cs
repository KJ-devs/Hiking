using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    // Événements liés aux utilisateurs
    public class UserCreatedEvent : DomainEvent
    {
        public Guid UserId { get; }

        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}