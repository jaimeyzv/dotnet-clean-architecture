using MediatR;

namespace Loans.Application.UseCases.PayInstallment
{
    public sealed record RepayInstallmentRequest() : IRequest<RepayInstallmentResponse>
    {
        public int LoanId { get; set; }
        public int InstallmentId { get; set; }
    }
}
