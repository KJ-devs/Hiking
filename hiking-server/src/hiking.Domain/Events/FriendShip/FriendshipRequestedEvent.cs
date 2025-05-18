
using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class FriendshipRequestedEvent : DomainEvent
    {
        public Guid RequesterId { get; }
        public Guid AddresseeId { get; }

        public FriendshipRequestedEvent(Guid requesterId, Guid addresseeId)
        {
            RequesterId = requesterId;
            AddresseeId = addresseeId;
        }
    }
}