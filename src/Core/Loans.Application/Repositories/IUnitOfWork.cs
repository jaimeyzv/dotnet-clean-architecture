namespace Loans.Application.Repositories
{
    public interface IUnitOfWork
    {
        public Task<bool> CommitAsync(CancellationToken cancellationToken);
    }
}
