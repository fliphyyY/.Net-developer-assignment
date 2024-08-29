using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.DbContext
{
    public class AppDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        public DbSet<Order> Orders { get; set; }

        public DbSet<Item> Items { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItem)
                .WithOne(i => i.Order)
                .HasForeignKey(i => i.OrderId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Property(o => o.Id).ValueGeneratedNever();

            modelBuilder.Entity<Item>()
                .Property(i => i.Id).ValueGeneratedNever();
        }
    }
}
