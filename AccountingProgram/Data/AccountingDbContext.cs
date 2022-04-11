namespace AccountingProgram.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using AccountingProgram.Data.Models;

    public class AccountingDbContext : IdentityDbContext
    {
        public AccountingDbContext(DbContextOptions<AccountingDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<SalesInvoice> SalesInvoices { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SalesInvoice>()
                .HasOne(si => si.Customer)
                .WithMany(c => c.SalesInvoices)
                .HasForeignKey(si => si.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Item>()
                .HasOne(i => i.ItemCategory)
                .WithMany(ic => ic.Items)
                .HasForeignKey(i => i.ItemCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<Item>()
                .HasOne(i => i.Vendor)
                .WithMany(v => v.Items)
                .HasForeignKey(i => i.VendorId)
                .OnDelete(DeleteBehavior.Cascade);*/

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.Route)
                .WithMany(r => r.Customers)
                .HasForeignKey(c => c.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
