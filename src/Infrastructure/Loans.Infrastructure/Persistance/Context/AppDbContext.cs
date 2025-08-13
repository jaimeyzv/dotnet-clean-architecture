using Loans.Infrastructure.Persistance.Configurations;
using Loans.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace Loans.Infrastructure.Persistance.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //load them all configuration classes automatically:
            //builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            builder.ApplyConfiguration(new LoanEntityConfiguration());
            base.OnModelCreating(builder);
        }

        public DbSet<LoanEntity> Loans { get; set; }
    }
}
