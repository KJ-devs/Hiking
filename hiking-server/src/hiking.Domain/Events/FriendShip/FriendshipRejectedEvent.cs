
using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class FriendshipRejectedEvent : DomainEvent
    {
        public Guid RequesterId { get; }
        public Guid AddresseeId { get; }

        public FriendshipRejectedEvent(Guid requesterId, Guid addresseeId)
        {
            RequesterId = requesterId;
            AddresseeId = addresseeId;

        }
    }
}