using AutoMapper;
using Loans.Application.Repositories;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Loans.Infrastructure.Persistance.Repositories
{
    public class InstallmentRepository : IInstallmentRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public InstallmentRepository(AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        public async Task<List<InstallmentDomain>> GetAllByLoanIdAsync(int loanId, CancellationToken cancellationToken)
        {
            var entityList = await this._context
                .Installments
                .Where( i => i.LoanInstallmentsLoanId == loanId)
                .ToListAsync();

            return _mapper.Map<List<InstallmentDomain>>(entityList);
        }
    }
}
