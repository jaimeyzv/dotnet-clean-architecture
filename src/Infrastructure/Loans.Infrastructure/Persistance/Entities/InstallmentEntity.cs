using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loans.Infrastructure.Persistance.Entities
{
    [Table("LoanInstallments")]
    public class InstallmentEntity
    {
        [Key]
        [Column("LoanInstallmentId")]
        public int LoanInstallmentId { get; set; }

        [Column("InstallmentNumber")]
        public int InstallmentNumber { get; set; }

        [Column("DueDate")]
        public DateTime DueDate { get; set; }

        [Column("Amount")]
        public decimal Amount { get; set; }

        [Column("IsPaid")]
        public bool IsPaid { get; set; }

        [Column("PaymentDate")]
        public DateTime? PaymentDate { get; set; }

        [Column("LoanInstallmentsLoanId")]
        public int LoanInstallmentsLoanId { get; set; }

        public LoanEntity Loan { get; set; }
    }
}
