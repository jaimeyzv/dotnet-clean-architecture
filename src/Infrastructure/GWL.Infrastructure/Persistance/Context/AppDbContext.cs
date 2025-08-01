using GWL.Infrastructure.Persistance.Configurations;
using GWL.Infrastructure.Persistance.Entities;
using Microsoft.EntityFrameworkCore;

namespace GWL.Infrastructure.Persistance.Context
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(UserEntityConfiguration).Assembly);
        }

        public DbSet<UserEntity> Users { get; set; }
    }
}
