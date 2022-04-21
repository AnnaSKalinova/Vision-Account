namespace AccountingProgram.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using AccountingProgram.Data.Models;

    public class AccountingDbContext : IdentityDbContext<User>
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
            : base(options)
        {
        }
        public DbSet<Accountant> Accountants { get; init; }
        
        public DbSet<Customer> Customers { get; init; }

        public DbSet<Driver> Drivers { get; init; }

        public DbSet<Item> Items { get; init; }

        public DbSet<ItemCategory> ItemCategories { get; init; }

        public DbSet<Route> Routes { get; init; }

        public DbSet<SalesInvoice> SalesInvoices { get; init; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accountant>()
                .HasOne<User>()
                .WithOne()
                .HasForeignKey<Accountant>(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<SalesInvoice>()
                .HasOne(si => si.Accountant)
                .WithMany(a => a.SalesInvoices)
                .HasForeignKey(si => si.AccountantId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesInvoice>()
                .HasOne(si => si.Customer)
                .WithMany(c => c.SalesInvoices)
                .HasForeignKey(si => si.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.ItemCategory)
                .WithMany(ic => ic.Items)
                .HasForeignKey(i => i.ItemCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Route)
                .WithMany(r => r.Customers)
                .HasForeignKey(c => c.RouteId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SalesInvoice>()
                .Property(si => si.Id)
                .UseIdentityColumn(seed: 220001, increment: 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
