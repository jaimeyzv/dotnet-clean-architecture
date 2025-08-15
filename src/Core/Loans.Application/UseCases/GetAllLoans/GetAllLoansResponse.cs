namespace Loans.Application.UseCases.GetAllLoans
{
    public sealed class GetAllLoansResponse
    {
        public IReadOnlyList<LoanItemResponse> Loans { get; init; }

        public GetAllLoansResponse(IReadOnlyList<LoanItemResponse> Loans)
        {
            this.Loans = Loans;
        }
    }

    public sealed record LoanItemResponse
    {
        public int LoanId { get; init; }
        public decimal Principal { get; init; }
        public decimal CurrentBalance { get; init; }
        public string BorrowerName { get; init; }
        public int DurationMonths { get; init; }
        public decimal InterestRate { get; init; }
        public decimal TotalPayment { get; init; }
        public string Status { get; set; }
        public int OverdueCount { get; set; }
    }
}
