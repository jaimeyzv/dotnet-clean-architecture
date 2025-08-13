using AutoMapper;
using Loans.Application.Repositories;
using Loans.Domain.Entities;
using MediatR;

namespace Loans.Application.UseCases.CreateLoan
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanRequest, CreateLoanResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoanRepository _loanRepository;
        private readonly IMapper _mapper;

        public CreateLoanHandler(IUnitOfWork unitOfWork,
            ILoanRepository loanRepository,
            IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._loanRepository = loanRepository;
            this._mapper = mapper;
        }

        public async Task<CreateLoanResponse> Handle(CreateLoanRequest request, CancellationToken cancellationToken)
        {
            var loanDomain = _mapper.Map<LoanDomain>(request);
            loanDomain.NewLoanCreation();
            //await _loanRepository.CreateAsync(loanDomain); taking off 'cancellationToken' ??
            await _loanRepository.CreateAsync(loanDomain, cancellationToken);
            var newId = await _unitOfWork.CommitAsync(cancellationToken);
            return _mapper.Map<CreateLoanResponse>(loanDomain);
        }
    }
}
