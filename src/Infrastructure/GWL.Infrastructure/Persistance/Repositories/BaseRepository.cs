using GWL.Domain.Entities;
using GWL.Domain.Interfaces;
using GWL.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GWL.Infrastructure.Persistance.Repositories
{
    public class BaseRepository<T>(AppDbContext context) : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext Context = context;

        public void Create(T entity)
        {
            entity.DateCrated = DateTimeOffset.UtcNow;
            Context.Add(entity);
        }

        public void Update(T entity)
        {
            entity.DateUpdated = DateTimeOffset.UtcNow;
            Context.Update(entity);
        }

        public void Delete(T entity)
            => Context.Remove(entity);

        public async Task<T?> Get(int id, CancellationToken cancellationToken)
            => await Context.Set<T>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<List<T>> GetAll(CancellationToken cancellationToken)
            => await Context.Set<T>().ToListAsync(cancellationToken);
    }
}
