using GWL.Domain.Interfaces;
using GWL.Infrastructure.Persistance.Context;

namespace GWL.Infrastructure.Persistance.Repositories
{
    public class UnitOfWork(AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task Commit(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
