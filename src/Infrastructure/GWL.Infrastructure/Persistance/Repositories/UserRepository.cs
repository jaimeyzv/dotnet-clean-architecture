using GWL.Domain.Entities;
using GWL.Domain.Interfaces;
using GWL.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GWL.Infrastructure.Persistance.Repositories
{
    public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository
    {
        public async Task<User?> Get(int userId, CancellationToken cancellationToken) 
        {
            var entity = await Context.Users.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
            if (entity == null) return new User(0, "", "", 0, "");

            return new User(entity.UserId, entity.FirstName, entity.LastName, entity.Age, entity.Gender);
        }
    }
}
