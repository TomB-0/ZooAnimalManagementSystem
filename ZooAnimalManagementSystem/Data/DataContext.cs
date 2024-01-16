using Microsoft.EntityFrameworkCore;
using ZooAnimalManagementSystem.Entities;

namespace ZooAnimalManagementSystem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Enclosure> Enclosures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
            .Property(a => a.EnclosureId)
            .IsRequired(false);

            modelBuilder.Entity<Animal>()
                .HasOne(a => a.Enclosure)
                .WithMany(e => e.Animals)
                .HasForeignKey(a => a.EnclosureId);

            modelBuilder.Entity<Enclosure>()
                .Property(e => e.Objects)
                .HasConversion(
                    v => string.Join(';', v), 
                    v => v.Split(';', StringSplitOptions.RemoveEmptyEntries).ToList()
                );
        }
    }
}
