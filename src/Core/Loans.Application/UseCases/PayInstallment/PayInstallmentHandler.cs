using AutoMapper;
using Loans.Application.Repositories;
using MediatR;

namespace Loans.Application.UseCases.PayInstallment
{
    public class PayInstallmentHandler : IRequestHandler<PayInstallmentRequest, PayInstallmentResponse>
    {
        private readonly IInstallmentRepository _installmentRepository;
        private readonly ILoanRepository _loanRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PayInstallmentHandler(IInstallmentRepository installmentRepository,
            ILoanRepository loanRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._installmentRepository = installmentRepository;
            this._loanRepository = loanRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PayInstallmentResponse> Handle(PayInstallmentRequest request, CancellationToken cancellationToken)
        {
            var domain = await this._installmentRepository.GetByIdAsync(request.InstallmentId, cancellationToken);
            domain.MarkAsPaid(DateTime.Today);
            await _installmentRepository.UpdateAsync(domain, cancellationToken);

            var allLoanInstallments = await this._installmentRepository.GetAllByLoanIdAsync(request.LoanId, cancellationToken);
            var restOfInstallments = allLoanInstallments.Where(i => i.InstallmentId != domain.InstallmentId).ToList();
            var isAnyPendingInstallment = restOfInstallments.Any(i => !i.IsPaid);

            var loanDomain = await this._loanRepository.GetByIdAsync(request.LoanId, cancellationToken);
            loanDomain.DiscountAfterInstallmentPayment(domain.Amount);

            if (!isAnyPendingInstallment)
            {                
                loanDomain.MarkAsPaid();                
            }

            await _loanRepository.UpdateAsyn(loanDomain, cancellationToken);

            await _unitOfWork.CommitAsync(cancellationToken);
            return new PayInstallmentResponse();
        }
    }
}
