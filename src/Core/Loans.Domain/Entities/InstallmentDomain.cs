namespace Loans.Domain.Entities
{
    public class InstallmentDomain
    {
        public InstallmentDomain(int number, DateTime dueDate, decimal amount)
        {
            InstallmentNumber = number;
            DueDate = dueDate;
            Amount = amount;
        }

        public InstallmentDomain() { }

        public int InstallmentId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPastDue { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int LoanId { get; set; }

        public void MarkAsPaid(DateTime paymentDate)
        {
            IsPaid = true;
            PaymentDate = paymentDate;
        }

        public void CalculateOverdue()
        {
            var now = DateTimeOffset.Now;
            this.IsPastDue = !this.IsPaid && this.DueDate < now;
        }
    }
}
