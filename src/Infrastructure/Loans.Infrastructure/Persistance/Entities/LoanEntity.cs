using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Loans.Infrastructure.Persistance.Entities
{
    [Table("Loans")]
    public class LoanEntity
    {
        [Key]
        [Column("LoanId")]
        public int LoanId { get; set; }

        [Column("Principal")]
        public decimal Principal { get; set; }

        [Column("CurrentBalance")]
        public decimal CurrentBalance { get; set; }

        [Column("BorrowerName")]
        public string BorrowerName { get; set; }

        [Column("DurationMonths")]
        public int DurationMonths { get; set; }

        [Column("InterestRate")]
        public decimal InterestRate { get; set; }

        [Column("TotalPayment")]
        public decimal TotalPayment { get; set; }

        [Column("Status")]
        public string Status { get; set; }
    }
}
