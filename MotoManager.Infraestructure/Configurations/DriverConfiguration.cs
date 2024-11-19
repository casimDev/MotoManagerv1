using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MotoManager.Domain.Entities;

namespace MotoManager.Infraestructure.Configurations
{
    public class DriverConfiguration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasIndex(d => d.DriverLicense).IsUnique();
            builder.HasIndex(d => d.Ein).IsUnique();
        }
    }
}
