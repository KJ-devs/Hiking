
using Hiking.Domain.Entities;

/// <summary>
/// Interface pour le repository des publications
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<Post> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Post>> GetByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Post>> GetFeedForUserAsync(Guid userId, int skip, int take, CancellationToken cancellationToken = default);
        Task<int> CountByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default);

        void Add(Post post);
        void Update(Post post);
        void Remove(Post post);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}