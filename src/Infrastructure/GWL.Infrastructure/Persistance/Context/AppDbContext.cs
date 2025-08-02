using GWL.Infrastructure.Persistance.Configurations;
using GWL.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace GWL.Infrastructure.Persistance.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
