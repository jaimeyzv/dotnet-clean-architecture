using AutoMapper;
using Loans.Application.Repositories;
using MediatR;

namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public class GetInstallmentsByLoanIdHandler : IRequestHandler<GetInstallmentsByLoanIdRequest, GetInstallmentsByLoanIdResponse>
    {
        private readonly IInstallmentRepository _installmentRepository;
        private readonly IMapper _mapper;

        public GetInstallmentsByLoanIdHandler(IInstallmentRepository installmentRepository,
            IMapper mapper)
        {
            this._installmentRepository = installmentRepository;
            this._mapper = mapper;
        }

        public async Task<GetInstallmentsByLoanIdResponse> Handle(GetInstallmentsByLoanIdRequest request, CancellationToken cancellationToken)
        {
            var installments = await _installmentRepository.GetAllByLoanIdAsync(request.LoanId, cancellationToken);

            foreach (var installment in installments) installment.CalculateOverdue();

            var response = new GetInstallmentsByLoanIdResponse
            {
                Installments = _mapper.Map<List<InstallmentItemResponse>>(installments)
            };            

            return response;
        }
    }
}
