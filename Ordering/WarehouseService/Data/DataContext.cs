using Microsoft.EntityFrameworkCore;
using WarehouseService.Entities;
using WarehouseService.Events;

namespace WarehouseService.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        
        public DbSet<Item> Items { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Item>()
                .HasMany(i => i.Events)
                .WithOne(e => e.Item)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}