using Loans.Domain.Entities;

namespace Loans.Application.Repositories
{
    public interface IInstallmentRepository
    {
        Task<InstallmentDomain> GetByIdAsync(int installmentId, CancellationToken cancellationToken);
        Task<List<InstallmentDomain>> GetAllByLoanIdAsync(int loanId, CancellationToken cancellationToken);
        Task Update(InstallmentDomain domain, CancellationToken cancellationToken);
    }
}
