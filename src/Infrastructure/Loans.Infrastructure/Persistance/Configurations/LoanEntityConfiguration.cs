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

            builder.Property(x => x.Principal)
                .IsRequired();

            builder.Property(x => x.CurrentBalance)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.BorrowerName)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.DurationMonths)
                .IsRequired();

            builder.Property(x => x.InterestRate)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.TotalPayment)
                .IsRequired()
                .HasPrecision(10, 2);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasMaxLength(10);
        }
    }
}
