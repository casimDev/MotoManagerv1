using Microsoft.EntityFrameworkCore;
using MotoManager.Domain.Entities;

namespace MotoManager.Infraestructure.Data
{
    public class MotorcycleManagerContext(DbContextOptions<MotorcycleManagerContext> options) : DbContext(options), IMotorcycleManagerContext
    {
        public DbSet<Motorcycle> Motorcycles { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<RentalPlans> RentalPlans { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MotorcycleRental> MotorcycleRentals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Aplica automaticamente as configurações
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MotorcycleManagerContext).Assembly);
        }
    }
}
