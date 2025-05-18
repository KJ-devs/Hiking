
using Hiking.Domain.Common;
namespace Hiking.Domain.Events
{
    public class FriendshipRemovedEvent : DomainEvent
    {
        public Guid RequesterId { get; }
        public Guid AddresseeId { get; }

        public FriendshipRemovedEvent(Guid requesterId, Guid addresseeId)
        {
            RequesterId = requesterId;
            AddresseeId = addresseeId;
        }
    }
}
