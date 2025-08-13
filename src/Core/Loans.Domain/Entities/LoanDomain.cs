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

        public List<InstallmentDomain> Installments;

        public void MakePayment(decimal paymentAmount)
        {
            if (Status != "Active" && Status != "active")
                throw new InvalidOperationException("Cannot make payments on a non-active loan");

            if (paymentAmount <= 0)
                throw new ArgumentException("Payment must be greater than 0");

            if (paymentAmount > CurrentBalance)
                throw new InvalidOperationException("Payment exceeds current balance");

            CurrentBalance -= paymentAmount;
            if (CurrentBalance == 0)
                Status = "Paid";
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
    }
}
