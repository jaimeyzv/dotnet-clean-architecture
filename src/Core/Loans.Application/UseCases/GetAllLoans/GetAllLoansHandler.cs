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
            var loans = await _loanRepository.GetAllAsync(cancellationToken);
            var responseItems = _mapper.Map<List<LoanItemResponse>>(loans);
            var responseList = new GetAllLoansResponse(responseItems);
            return responseList;
        }
    }
}
