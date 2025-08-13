using Loans.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Loans.Infrastructure.Persistance.Configurations
{
    public class InstallmentEntityConfiguration : IEntityTypeConfiguration<InstallmentEntity>    
    {
        public void Configure(EntityTypeBuilder<InstallmentEntity> builder)
        {
            builder.ToTable("LoanInstallments");

            builder.HasKey(x => x.LoanInstallmentId);

            builder.Property(x => x.LoanInstallmentId)
                   .HasColumnName("LoanInstallmentId")
                   .ValueGeneratedOnAdd(); // IDENTITY(1,1)

            builder.Property(x => x.InstallmentNumber)
                   .HasColumnName("InstallmentNumber")
                   .IsRequired();

            builder.Property(x => x.DueDate)
                   .HasColumnName("DueDate")
                   .IsRequired();

            builder.Property(x => x.Amount)
                   .HasColumnName("Amount")
                   .IsRequired()
                   .HasPrecision(10, 2);

            builder.Property(x => x.IsPaid)
                   .HasColumnName("IsPaid")
                   .IsRequired();

            builder.Property(x => x.PaymentDate)
                   .HasColumnName("PaymentDate")
                   .IsRequired(false);

            builder.Property(x => x.LoanInstallmentsLoanId)
                   .HasColumnName("LoanInstallmentsLoanId")
                   .IsRequired();

            builder.HasIndex(x => x.LoanInstallmentsLoanId)
                   .HasDatabaseName("IX_LoanInstallments_LoanId");
        }
    }
}
