using DesafioAutoGlass.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DesafioAutoGlass.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Product>().Property(e => e.Description).IsRequired().HasMaxLength(100);
        }
        public DbSet<Product> Products { get; set; }

    }
}
