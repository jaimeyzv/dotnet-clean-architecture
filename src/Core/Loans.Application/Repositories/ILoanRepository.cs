using Loans.Domain.Entities;

namespace Loans.Application.Repositories
{
    public interface ILoanRepository
    {
        public Task<List<LoanDomain>> GetAllAsync(CancellationToken cancellationToken);
        public Task<LoanDomain> GetByIdAsync(int loanId, CancellationToken cancellationToken);
        Task CreateAsync(LoanDomain domain, CancellationToken cancellationToken);

        //Having update method will requiere to recalculate interest, periods and totalPayment
        //Implemente later
    }
}
