using System.Reflection;
using AirBnb.Server.App.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.App.Persistence.DataContexts;

public class LocationsDbContext(DbContextOptions<LocationsDbContext> dbContextOptions) : DbContext(dbContextOptions)
{
    public DbSet<Location> Locations => Set<Location>();

    public DbSet<LocationCategory> LocationCategories => Set<LocationCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LocationsDbContext).Assembly);
    }
}