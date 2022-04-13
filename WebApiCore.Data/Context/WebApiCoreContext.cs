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
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
