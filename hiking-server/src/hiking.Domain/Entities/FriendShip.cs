using Hiking.Domain.Common;
using Hiking.Domain.Enums;
using Hiking.Domain.Events;
namespace Hiking.Domain.Entities
{
    /// <summary>
    /// Représente une relation d'amitié entre deux utilisateurs
    /// </summary>
    public class Friendship : Entity
    {
        // Propriétés
        public Guid RequesterId { get; private set; }
        public Guid AddresseeId { get; private set; }
        public FriendshipStatus Status { get; private set; }
        public DateTime RequestedAt { get; private set; }
        public DateTime? AcceptedAt { get; private set; }

        // Navigation properties
        public User Requester { get; private set; }
        public User Addressee { get; private set; }

        // Constructeur privé pour EF Core
        private Friendship() { }

        // Constructeur principal
        public Friendship(Guid requesterId, Guid addresseeId)
        {
            if (requesterId == addresseeId)
                throw new ArgumentException("Un utilisateur ne peut pas être ami avec lui-même");

            RequesterId = requesterId;
            AddresseeId = addresseeId;
            Status = FriendshipStatus.Pending;
            RequestedAt = DateTime.UtcNow;
        }

        // Méthodes de domaine
        public void Accept()
        {
            if (Status != FriendshipStatus.Pending)
                throw new InvalidOperationException($"La demande d'ami ne peut pas être acceptée dans l'état {Status}");

            Status = FriendshipStatus.Accepted;
            AcceptedAt = DateTime.UtcNow;

            AddDomainEvent(new FriendshipAcceptedEvent(RequesterId, AddresseeId));
        }

        public void Reject()
        {
            if (Status != FriendshipStatus.Pending)
                throw new InvalidOperationException($"La demande d'ami ne peut pas être rejetée dans l'état {Status}");

            Status = FriendshipStatus.Rejected;

            AddDomainEvent(new FriendshipRejectedEvent(RequesterId, AddresseeId));
        }

        public void Remove()
        {
            if (Status != FriendshipStatus.Accepted)
                throw new InvalidOperationException($"L'amitié ne peut pas être supprimée dans l'état {Status}");

            Status = FriendshipStatus.Removed;

            AddDomainEvent(new FriendshipRemovedEvent(RequesterId, AddresseeId));
        }
    }
}