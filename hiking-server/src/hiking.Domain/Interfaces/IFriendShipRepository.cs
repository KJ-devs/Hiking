using Hiking.Domain.Entities;

/// <summary>
/// Interface pour le repository des relations d'amitié
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface IFriendshipRepository
    {
        Task<Friendship> GetAsync(Guid requesterId, Guid addresseeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Friendship>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Friendship>> GetPendingRequestsForUserAsync(Guid addresseeId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Friendship>> GetSentRequestsForUserAsync(Guid requesterId, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetFriendsAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<bool> AreFriendsAsync(Guid user1Id, Guid user2Id, CancellationToken cancellationToken = default);
        Task<int> CountFriendsAsync(Guid userId, CancellationToken cancellationToken = default);

        void Add(Friendship friendship);
        void Update(Friendship friendship);
        void Remove(Friendship friendship);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}