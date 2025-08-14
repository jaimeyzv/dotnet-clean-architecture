using AutoMapper;
using Loans.Application.Repositories;
using MediatR;

namespace Loans.Application.UseCases.PayInstallment
{
    public class PayInstallmentHandler : IRequestHandler<PayInstallmentRequest, PayInstallmentResponse>
    {
        private readonly IInstallmentRepository _installmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PayInstallmentHandler(IInstallmentRepository installmentRepository,
            IUnitOfWork unitOfWork,
           IMapper mapper)
        {
            this._installmentRepository = installmentRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PayInstallmentResponse> Handle(PayInstallmentRequest request, CancellationToken cancellationToken)
        {
            var domain = await _installmentRepository.GetByIdAsync(request.InstallmentId, cancellationToken);
            domain.MarkAsPaid(DateTime.Today);
            await _installmentRepository.Update(domain, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new PayInstallmentResponse();
        }
    }
}
