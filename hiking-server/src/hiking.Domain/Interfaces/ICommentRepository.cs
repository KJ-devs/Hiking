using Hiking.Domain.Entities;

/// <summary>
/// Interface pour le repository des commentaires
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task<Comment> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Comment>> GetByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Comment>> GetByAuthorIdAsync(Guid authorId, CancellationToken cancellationToken = default);
        Task<int> CountByPostIdAsync(Guid postId, CancellationToken cancellationToken = default);

        void Add(Comment comment);
        void Update(Comment comment);
        void Remove(Comment comment);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}