using MediatR;

namespace Loans.Application.UseCases.PayInstallment
{
    public sealed record PayInstallmentRequest() : IRequest<PayInstallmentResponse>
    {
        public int LoanId { get; set; }
        public int InstallmentId { get; set; }
    }
}
