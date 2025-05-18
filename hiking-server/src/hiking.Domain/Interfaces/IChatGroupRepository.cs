using Hiking.Domain.Entities;
using Hiking.Domain.Events;

/// <summary>
/// Interface pour le repository des groupes de chat
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface IChatGroupRepository
    {
        Task<ChatGroup> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatGroup>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetMembersAsync(Guid groupId, CancellationToken cancellationToken = default);
        Task<bool> IsMemberAsync(Guid groupId, Guid userId, CancellationToken cancellationToken = default);
        Task<bool> IsAdminAsync(Guid groupId, Guid userId, CancellationToken cancellationToken = default);

        void Add(ChatGroup group);
        void Update(ChatGroup group);
        void Remove(ChatGroup group);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
