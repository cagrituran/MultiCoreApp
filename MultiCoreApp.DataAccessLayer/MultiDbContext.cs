using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.Models;
using MultiCoreApp.DataAccessLayer.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiCoreApp.DataAccessLayer.Seeds;

namespace MultiCoreApp.DataAccessLayer
{
    public class MultiDbContext:DbContext
    {

        public MultiDbContext(DbContextOptions<MultiDbContext> options):base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSeed(new Guid[] { g1, g2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new Guid[] { g1, g2 }));
        }
    }

}
