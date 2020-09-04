using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Peak.Discount.Model;

namespace Peak.Discount.Dashboard.Context
{
    public class AppDbContext:IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }


        public DbSet<Product> Product { get; set; }
        public DbSet<Pack> Pack { get; set; }

        public DbSet<PackProduct> PackProduct { get; set; }
        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PackProduct>().HasKey(c => new { c.PackId, c.ProductId });
        }
     
    }
}
