using AutoMapper;
using Loans.Application.Repositories;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Context;
using Loans.Infrastructure.Persistance.Entities;
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

        public async Task<InstallmentDomain> GetByIdAsync(int installmentId, CancellationToken cancellationToken)
        {
            var entity = await _context
                    .Installments
                    .FirstOrDefaultAsync(x => x.LoanInstallmentId == installmentId, cancellationToken);

            if (entity == null) return null;

            var domain = _mapper.Map<InstallmentDomain>(entity);

            return domain;
        }

        public async Task<List<InstallmentDomain>> GetAllByLoanIdAsync(int loanId, CancellationToken cancellationToken)
        {
            var entityList = await this._context
                .Installments
                .Where( i => i.LoanInstallmentsLoanId == loanId)
                .ToListAsync();

            return _mapper.Map<List<InstallmentDomain>>(entityList);
        }

        public async Task Update(InstallmentDomain domain, CancellationToken cancellationToken)
        {
            var entity = await _context
                    .Installments
                    .SingleAsync(x => x.LoanInstallmentId == domain.InstallmentId, cancellationToken);
            _context.Entry(entity).State = EntityState.Detached;
            var newEntity = _mapper.Map<InstallmentEntity>(domain);
            _context.Installments.Update(newEntity);
        }
    }
}
