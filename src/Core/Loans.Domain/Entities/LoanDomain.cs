namespace Loans.Domain.Entities
{
    public sealed class LoanDomain
    {
        public LoanDomain()
        {
            this.Installments = new List<InstallmentDomain>();
        }

        public int LoanId { get; set; }
        public decimal Principal { get; set; }
        public decimal CurrentBalance { get; set; }
        public string BorrowerName { get; set; }
        public int DurationMonths { get; set; }
        public decimal InterestRate { get; set; }
        public decimal TotalPayment { get; set; }
        public string Status { get; set; }
        public int OverdueCount { get; set; }

        public List<InstallmentDomain> Installments;

        public void MarkAsPaid()
        {
            this.Status = "Paid";
        }

        public void DiscountAfterInstallmentPayment(decimal paymentAmount)
        {
            if (paymentAmount <= 0)
                throw new Exception("Payment amount must be greater than zero.");

            if (paymentAmount > CurrentBalance)
                throw new Exception("Payment amount cannot exceed the current balance.");

            CurrentBalance -= paymentAmount;
        }

        public void NewLoanCreation()
        {
            if (Principal <= 0)
                throw new ArgumentException("Loan amount must be greater than zero");

            if (string.IsNullOrWhiteSpace(BorrowerName))
                throw new ArgumentException("Applicant name is required");

            this.InterestRate = 0.1m; // 10% monthly
            decimal totalInterest = Principal * InterestRate * DurationMonths;
            decimal totalPayment = Principal + totalInterest;

            this.CurrentBalance = totalPayment;
            this.TotalPayment = totalPayment;
            this.Status = "Active";
        }

        public void GenerateInstallments(DateTime firstDueDate)
        {            
            var monthlyAmount = Math.Round(TotalPayment / DurationMonths, 2);

            for (int i = 1; i <= DurationMonths; i++)
            {
                Installments.Add(new InstallmentDomain(i, firstDueDate.AddMonths(i - 1), monthlyAmount));
            }
        }

        public void CalculateOverdueInstallments()
        {
            var now = DateTimeOffset.Now;
            this.OverdueCount = this.Installments?
                .Count(i => !i.IsPaid && i.DueDate < now) ?? 0;
            this.Status = this.OverdueCount > 0 ? "Overdue" : this.Status;
        }
    }
}
