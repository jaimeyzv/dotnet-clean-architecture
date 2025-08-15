namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public sealed class GetInstallmentsByLoanIdResponse
    {
        public List<InstallmentItemResponse> Installments { get; set; } = new();
    }

    public sealed class InstallmentItemResponse
    {
        public int InstallmentId { get; init; }
        public int InstallmentNumber { get; init; }
        public DateTime DueDate { get; init; }
        public decimal Amount { get; init; }
        public bool IsPaid { get; init; }
        public bool IsPastDue { get; init; }
        public DateTime? PaymentDate { get; init; }
        public int LoanId { get; init; }
    }
}
