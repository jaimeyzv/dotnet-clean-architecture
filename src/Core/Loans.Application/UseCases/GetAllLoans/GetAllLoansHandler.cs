using AutoMapper;
using Loans.Application.Repositories;
using MediatR;

namespace Loans.Application.UseCases.GetAllLoans
{
    public class GetAllLoansHandler : IRequestHandler<GetAllLoansRequest, GetAllLoansResponse>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetAllLoansHandler(ILoanRepository loanRepository,
            IMapper mapper)
        {
            this._loanRepository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<GetAllLoansResponse> Handle(GetAllLoansRequest request, CancellationToken cancellationToken)
        {
            var now = DateTimeOffset.UtcNow;

            var loans = await _loanRepository.GetAllAsync(cancellationToken);

            var overdueByLoanId = loans.ToDictionary(
                l => l.LoanId,
                l => l.Installments?.Count(i => !i.IsPaid && i.DueDate < now) ?? 0
            );

            var responseItems = _mapper.Map<List<LoanItemResponse>>(loans);

            foreach (var item in responseItems)
            {
                item.OverdueCount = overdueByLoanId.TryGetValue(item.LoanId, out var c) ? c : 0;
                item.Status = item.OverdueCount > 0 ? "Overdue" : item.Status;
            }

            return new GetAllLoansResponse(responseItems);
        }
    }
}
