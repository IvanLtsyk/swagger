using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCore.Data.Models;

namespace WebApiCore.Data
{
    public class WebApiCoreContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CurrentWeather> Weather { get; set; }

        public WebApiCoreContext(DbContextOptions<WebApiCoreContext> options)
            :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {}

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {}
    }
}
