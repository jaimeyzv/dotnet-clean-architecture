using MediatR;

namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public class GetInstallmentsByLoanIdRequest : IRequest<GetInstallmentsByLoanIdResponse>
    {
        public int LoanId { get; set; }
    }
}
