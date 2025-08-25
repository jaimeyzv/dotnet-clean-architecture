using AutoMapper;
using Loans.Application.Repositories;
using Loans.Application.UseCases.Dtos;
using Loans.Application.UseCases.GetAllLoans;
using MediatR;

namespace Loans.Application.UseCases.GetLoanByPagination
{
    public class GetLoanByPaginationHandler : IRequestHandler<GetLoanByPaginationRequest, PagedList<LoanItemResponse>>
    {
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public GetLoanByPaginationHandler(ILoanRepository loanRepository,
            IMapper mapper)
        {
            this._loanRepository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<PagedList<LoanItemResponse>> Handle(GetLoanByPaginationRequest request, CancellationToken cancellationToken)
        {
            return await _loanRepository.GetPagedLoansAsync(request.Parameters, cancellationToken);
        }

    }
}
