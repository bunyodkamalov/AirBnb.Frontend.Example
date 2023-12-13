using AirBnb.Server.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.Server.App.Persistence.EntityConfigurations;

public class LocationConfiguration : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.Property(location => location.Name).IsRequired().HasMaxLength(256);
        builder.Property(location => location.ImageUrl).IsRequired();
        builder.Property(location => location.BuiltYear).IsRequired();
        builder.Property(location => location.PricePerNight).IsRequired();
    }
}