
using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class FriendshipAcceptedEvent : DomainEvent
    {
        public Guid RequesterId { get; }
        public Guid AddresseeId { get; }

        public FriendshipAcceptedEvent(Guid requesterId, Guid addresseeId)
        {
            RequesterId = requesterId;
            AddresseeId = addresseeId;
        }
    }
}
