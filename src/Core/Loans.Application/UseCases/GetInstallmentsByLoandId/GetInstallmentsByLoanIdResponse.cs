namespace Loans.Application.UseCases.GetInstallmentsByLoandId
{
    public sealed class GetInstallmentsByLoanIdResponse
    {
        public List<InstallmentItemResponse> Installments { get; set; } = new();
    }

    public sealed class InstallmentItemResponse
    {
        public int InstallmentId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int LoanId { get; set; }
    }
}
