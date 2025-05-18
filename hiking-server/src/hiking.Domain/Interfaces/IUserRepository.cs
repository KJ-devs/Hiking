using Hiking.Domain.Entities;


namespace Hiking.Domain.Interfaces
{
    /// <summary>
    /// Interface pour le repository des utilisateurs
    /// </summary>
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<User> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
        Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<User>> GetByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
        Task<bool> ExistsByUsernameAsync(string username, CancellationToken cancellationToken = default);
        Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

        void Add(User user);
        void Update(User user);
        void Remove(User user);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}