
/// <summary>
/// Interface pour le unit of work qui coordonne tous les repositories
/// </summary>
namespace Hiking.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IPostRepository Posts { get; }
        ICommentRepository Comments { get; }
        IFriendshipRepository Friendships { get; }
        IChatMessageRepository ChatMessages { get; }
        IChatGroupRepository ChatGroups { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}