using AirBnb.Server.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirBnb.Server.App.Persistence.EntityConfigurations;

public class LocationCategoryConfiguration : IEntityTypeConfiguration<LocationCategory>
{
    public void Configure(EntityTypeBuilder<LocationCategory> builder)
    {
        builder.Property(locationCategory => locationCategory.ImageUrl).IsRequired();
        builder.Property(locationCategory => locationCategory.Name).IsRequired().HasMaxLength(64);
    }
}