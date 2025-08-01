using GWL.Domain.Entities;

namespace GWL.Domain.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        public Task<User?> Get(int userId, CancellationToken cancellationToken);
    }
}
