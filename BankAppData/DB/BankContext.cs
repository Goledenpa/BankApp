using BankAppData.Config;
using BankAppData.Model;
using Microsoft.EntityFrameworkCore;

namespace BankAppData.DB
{
    public class BankContext : DbContext
    {
        public DbSet<AccountDB> Accounts { get; set; }
        public DbSet<CustomerDB> Customers { get; set; }

        public BankContext() : base() { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Session.Instance.ConnectionString);
            //Commented out for Add-Migration
            optionsBuilder.UseSqlServer("Server=192.168.78.140;Database=BankApp;User Id=BankUser;Password=BankPassword;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountDB>(e =>
            {
                e.HasKey(x => x.Id);

                e.HasOne(x => x.Client).WithMany(x => x.Accounts)
                .HasForeignKey(x => x.CustomerId)
                .HasConstraintName("FK_Account_Client");
            });

            modelBuilder.Entity<CustomerDB>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.FirstName).IsRequired().HasMaxLength(35);
                e.Property(x => x.LastName).IsRequired().HasMaxLength(35);
                e.Property(x => x.Username).IsRequired().HasMaxLength(15);
                e.Property(x => x.Password).IsRequired().HasMaxLength(24);
                e.Property(x => x.Country).IsRequired().HasMaxLength(50);
                e.Property(x => x.Region).IsRequired().HasMaxLength(50);
                e.Property(x => x.City).IsRequired().HasMaxLength(50);
                e.Property(x => x.Address).IsRequired().HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
