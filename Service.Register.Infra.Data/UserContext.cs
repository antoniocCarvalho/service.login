using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Service.Register.Domain.Aggregates;

namespace Service.Register.Infra.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User")
            .HasKey(u => u.Id);
        }

        public class UserContextFactory : IDesignTimeDbContextFactory<UserContext>
        {
            public UserContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
                optionsBuilder.UseSqlServer("Server=localhost;Database=Indumepi;Trusted_Connection=True;TrustServerCertificate=True");

                return new UserContext(optionsBuilder.Options);
            }
        }
    }
}
