using System;
using Microsoft.EntityFrameworkCore;
using WebApiCore.Data.Models;

namespace WebApiCore.Data
{
    public class WebApiCoreContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CurrentWeather> Weather { get; set; }

        public WebApiCoreContext(DbContextOptions<WebApiCoreContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 1, Name = "Jon", BirthDate = new DateTime(2000, 01, 01), });
            modelBuilder.Entity<Customer>().HasData(new Customer { Id = 2, Name = "Ben", BirthDate = new DateTime(2002, 02, 02), });

        }
    }
}
