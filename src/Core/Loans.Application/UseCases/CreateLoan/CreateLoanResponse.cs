namespace Loans.Application.UseCases.CreateLoan
{
    public sealed class CreateLoanResponse
    {
        public int LoanId { get; set; }
        public decimal Principal { get; set; }
        public decimal CurrentBalance { get; set; }
        public string BorrowerName { get; set; }
        public int DurationMonths { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalPayment { get; set; }
        public string Status { get; set; }
    }
}
