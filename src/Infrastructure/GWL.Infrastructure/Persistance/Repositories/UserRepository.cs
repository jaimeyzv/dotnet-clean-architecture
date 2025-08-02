using AutoMapper;
using GWL.Domain.Entities;
using GWL.Domain.Interfaces;
using GWL.Infrastructure.Persistance.Context;
using GWL.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace GWL.Infrastructure.Persistance.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Create(User domain, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserEntity>(domain);

            _context.Users.Add(userEntity);
            //await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<User?> GetByUserId(int userId, CancellationToken cancellationToken)
        {
            var entity = await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId, cancellationToken);
            if (entity == null) return null;

            return new User(entity.UserId, entity.FirstName, entity.LastName, entity.Age, entity.Gender);
        }
    }
}
