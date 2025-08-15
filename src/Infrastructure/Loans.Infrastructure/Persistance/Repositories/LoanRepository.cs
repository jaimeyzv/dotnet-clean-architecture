﻿using AutoMapper;
using Loans.Application.Repositories;
using Loans.Domain.Entities;
using Loans.Infrastructure.Persistance.Context;
using Loans.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loans.Infrastructure.Persistance.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public LoanRepository(AppDbContext context,
            IMapper mapper)
        {
            this._context = context;
            this._mapper = mapper;
        }

        /// <summary>
        /// This saved the loan entity to the database and its calculated installments built in the LoanDomain.
        /// </summary>
        /// <param name="domain"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task CreateAsync(LoanDomain domain, CancellationToken cancellationToken)
        {
            var loanEntity = _mapper.Map<LoanEntity>(domain);
            _context.Loans.Add(loanEntity);
            await Task.CompletedTask;
        }

        public async Task<List<LoanDomain>> GetAllAsync(CancellationToken cancellationToken)
        {
            var entityList = await this._context
                .Loans
                .Include(l => l.Installments)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<List<LoanDomain>>(entityList);
        }

        public async Task<LoanDomain> GetByIdAsync(int loanId, CancellationToken cancellationToken)
        {
            var entity = await _context
                    .Loans
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.LoanId == loanId, cancellationToken);

            if (entity == null) return null;

            var loanDomain = _mapper.Map<LoanDomain>(entity);

            return loanDomain;
        }

        public async Task UpdateAsyn(LoanDomain domain, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await _context
                    .Loans
                    .SingleAsync(x => x.LoanId == domain.LoanId, cancellationToken);
                _context.Entry(entity).State = EntityState.Detached;

                var newEntity = _mapper.Map<LoanEntity>(domain);

                _context.Attach(newEntity);
                _context.Entry(newEntity).State = EntityState.Modified;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
