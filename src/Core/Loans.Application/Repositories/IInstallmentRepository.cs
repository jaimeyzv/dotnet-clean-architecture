using Loans.Domain.Entities;

namespace Loans.Application.Repositories
{
    public interface IInstallmentRepository
    {
        public Task<List<InstallmentDomain>> GetAllByLoanIdAsync(int loanId, CancellationToken cancellationToken);
    }
}
