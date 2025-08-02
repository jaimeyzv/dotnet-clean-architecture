using GWL.Domain.Entities;

namespace GWL.Domain.Interfaces
{
    public interface IUserRepository
    {
        public Task<User?> GetByUserId(int userId, CancellationToken cancellationToken);
        Task Create(User domain, CancellationToken cancellationToken);
    }
}
