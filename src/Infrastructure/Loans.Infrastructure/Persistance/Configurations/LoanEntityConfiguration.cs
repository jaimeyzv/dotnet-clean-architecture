using Loans.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loans.Infrastructure.Persistance.Configurations
{
    public class LoanEntityConfiguration : IEntityTypeConfiguration<LoanEntity>
    {
        public void Configure(EntityTypeBuilder<LoanEntity> builder)
        {
            builder.HasKey(x => x.LoanId);

            builder.Property(x => x.LoanId)
               .HasColumnName("LoanId")
               .ValueGeneratedOnAdd(); // IDENTITY(1,1)

            builder.Property(x => x.Principal)
                .HasColumnName("Principal")
                .IsRequired();

            builder.Property(x => x.CurrentBalance)
                .HasColumnName("CurrentBalance")
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.BorrowerName)
                .HasColumnName("BorrowerName")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DurationMonths)
                .HasColumnName("DurationMonths")
                .IsRequired();

            builder.Property(x => x.InterestRate)
                .HasColumnName("InterestRate")
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.TotalPayment)
                .HasColumnName("TotalPayment")
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.Status)
                .HasColumnName("Status")
                .IsRequired()
                .HasMaxLength(10);

            builder.HasMany(x => x.Installments)
               .WithOne(i => i.Loan)
               .HasForeignKey(i => i.LoanInstallmentsLoanId)
               .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
