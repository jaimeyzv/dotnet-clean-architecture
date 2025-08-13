using Loans.Application.Repositories;
using Loans.Infrastructure.Persistance.Context;

namespace Loans.Infrastructure.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var success = (await _context.SaveChangesAsync(cancellationToken)) > 0;

                // commit if everything went well
                await transaction.CommitAsync(cancellationToken);

                return success;
            }
            catch(Exception e)
            {
                // rollback if something failed
                await transaction.RollbackAsync(cancellationToken);
                throw;
            }
        }
    }
}
