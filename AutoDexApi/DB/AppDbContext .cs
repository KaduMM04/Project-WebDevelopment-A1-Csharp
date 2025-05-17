using Microsoft.EntityFrameworkCore;
using AutoDexApi.Models;

namespace AutoDexApi.DB
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Car> Cars { get; set; }
        public DbSet<Motorcycle> Motorcycles { get; set;}
        
    }
}