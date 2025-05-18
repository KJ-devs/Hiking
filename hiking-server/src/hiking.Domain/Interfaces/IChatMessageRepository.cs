using Hiking.Domain.Entities;

/// <summary>
/// Interface pour le repository des messages de chat
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface IChatMessageRepository
    {
        Task<ChatMessage> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatMessage>> GetPrivateMessagesAsync(Guid user1Id, Guid user2Id, int skip, int take, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatMessage>> GetGroupMessagesAsync(Guid groupId, int skip, int take, CancellationToken cancellationToken = default);
        Task<IEnumerable<ChatMessage>> GetUnreadMessagesForUserAsync(Guid userId, CancellationToken cancellationToken = default);
        Task<int> CountUnreadPrivateMessagesAsync(Guid recipientId, CancellationToken cancellationToken = default);

        void Add(ChatMessage message);
        void Update(ChatMessage message);
        void Remove(ChatMessage message);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}