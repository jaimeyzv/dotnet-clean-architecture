using Loans.Domain.Types;

namespace Loans.Domain.Entities
{
    public class InstallmentDomain
    {
        public InstallmentDomain(int number, DateTime dueDate, decimal amount)
        {
            InstallmentNumber = number;
            DueDate = dueDate;
            Amount = amount;            
            Status = InstallmentStatus.Pending; // Default when creating
        }

        public InstallmentDomain() { }

        public int InstallmentId { get; set; }
        public int InstallmentNumber { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public InstallmentStatus Status { get; set; }        
        public DateTime? PaymentDate { get; set; }
        public int LoanId { get; set; }

        public void MakeRepayment(DateTime paymentDate)
        {
            Status = InstallmentStatus.Paid;
            PaymentDate = paymentDate;
        }

        public void CalculateOverdue()
        {
            var now = DateTimeOffset.Now;
            this.Status = (this.Status != InstallmentStatus.Paid && this.DueDate < now)
                ? InstallmentStatus.Overdue 
                : this.Status;
        }
    }
}
