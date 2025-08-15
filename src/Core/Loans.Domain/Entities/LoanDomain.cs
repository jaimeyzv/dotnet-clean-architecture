using Loans.Domain.Types;

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
        public RepaymentModality RepaymentModality { get; set; }
        public LoanStatus Status { get; set; }
        public int OverdueCount { get; set; }

        public List<InstallmentDomain> Installments;

        public void MarkAsPaid()
        {
            this.Status = LoanStatus.PaidOff;
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
            this.Status = LoanStatus.Active;
        }

        public void GenerateInstallments()
        {
            if (DurationMonths <= 0) throw new InvalidOperationException("DurationMonths must be > 0.");
            if (TotalPayment <= 0m) throw new InvalidOperationException("TotalPayment must be > 0.");

            Installments.Clear();

            var firstDueDate = GetFirstDueDate();
            var endExclusive = firstDueDate.AddMonths(DurationMonths);

            // 1) Build due dates according to modality
            List<DateTime> dueDates = RepaymentModality switch
            {
                RepaymentModality.Weekly =>
                    EnumerateByDays(firstDueDate, endExclusive, 7).ToList(),

                RepaymentModality.Every15Days =>
                    EnumerateByDays(firstDueDate, endExclusive, 15).ToList(),

                RepaymentModality.Monthly =>
                    Enumerable.Range(0, DurationMonths)
                              .Select(i => firstDueDate.AddMonths(i))
                              .ToList(),

                _ => throw new InvalidOperationException("Unknown repayment modality.")
            };

            if (dueDates.Count == 0) return;

            // 2) Even amounts with correct rounding (last installment absorbs remainder)
            int n = dueDates.Count;
            decimal baseAmount = Math.Round(TotalPayment / n, 2, MidpointRounding.AwayFromZero);
            decimal remainder = TotalPayment - baseAmount * n;
            decimal lastAmount = Math.Round(baseAmount + remainder, 2, MidpointRounding.AwayFromZero);

            for (int i = 0; i < n; i++)
            {
                var amount = (i == n - 1) ? lastAmount : baseAmount;
                Installments.Add(new InstallmentDomain(i + 1, dueDates[i], amount));
            }
        }

        private static IEnumerable<DateTime> EnumerateByDays(DateTime startInclusive, DateTime endExclusive, int stepDays)
        {
            var d = startInclusive;
            while (d < endExclusive)
            {
                yield return d;
                d = d.AddDays(stepDays);
            }
        }

        private DateTime GetFirstDueDate()
        {            
            var today = DateTime.Today;

            return RepaymentModality switch
            {
                RepaymentModality.Weekly => today.AddDays(7),       // First in 7 days
                RepaymentModality.Every15Days => today.AddDays(15), // First in 15 days
                RepaymentModality.Monthly => today.AddMonths(1),    // First monthly int the same day
                _ => throw new InvalidOperationException("Unknown repayment modality.")
            };
        }

        public void CalculateOverdueInstallments()
        {
            var now = DateTimeOffset.Now;
            this.OverdueCount = this.Installments?
                .Count(i => i.Status != InstallmentStatus.Paid && i.DueDate < now) ?? 0;
            this.Status = this.OverdueCount > 0 ? LoanStatus.Delinquent : this.Status;
        }
    }
}
