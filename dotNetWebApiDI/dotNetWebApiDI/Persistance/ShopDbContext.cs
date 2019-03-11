namespace dotNetWebApiDI
{
    using dotNetWebApiDI.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Configuration;
    using System.Linq;

    public class ShopDbContext : DbContext
    {
        public ShopDbContext(string connectionName)
            : base(connectionName)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Customer>()
                .HasKey(e => e.Id);

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.Id)
                .HasColumnName("ID");

            modelBuilder
                .Entity<Customer>()
                .Property(e => e.FirstName)
                .HasColumnName("FIRSTNAME");
        }
    }


}