using Microsoft.EntityFrameworkCore;
using AutoDexApi.Models;

namespace AutoDexApi.DB
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) {}

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle>  Motorcycles  { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
            // Configura herança TPT: mapeia cada tipo para sua tabela própria
            modelBuilder.Entity<Vehicle>().UseTptMappingStrategy(); // define TPT (opcional, mas explícito)
            modelBuilder.Entity<Vehicle>().ToTable("Vehicles");
            modelBuilder.Entity<Car>()
                .ToTable("Cars", tableBuilder =>
                    tableBuilder.Property(v => v.Id).HasColumnName("CarId"));
            modelBuilder.Entity<Motorcycle>()
                .ToTable("Motorcycles", tableBuilder =>
                    tableBuilder.Property(v => v.Id).HasColumnName("MotorcycleId"));

        }
    }
}