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

        public int LoanInstallmentId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }

        public void MarkAsPaid(DateTime paymentDate)
        {
            IsPaid = true;
            PaymentDate = paymentDate;
        }
    }
}
