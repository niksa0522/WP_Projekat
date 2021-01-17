using Microsoft.EntityFrameworkCore;

namespace BackEnd.Models
{
    public class PCShopContext : DbContext
    {
        public DbSet<Warehouse> Warehouses {get;set;}
        public DbSet<PC> PCs {get;set;}
        public DbSet<Motherboard> Motherboards {get;set;}
        public DbSet<Memory> Memories{get;set;}

        public PCShopContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Memory>()
            .HasOne(p => p.Motherboard)
            .WithMany(b => b.Memory);
        modelBuilder.Entity<Motherboard>()
            .HasMany(p=>p.Memory)
            .WithOne(b=>b.Motherboard)
            .OnDelete(DeleteBehavior.Cascade);
    }
        
    }
}