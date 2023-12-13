using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Caching;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Persistence.Caching;
using AirBnb.Server.App.Persistence.DataContexts;
using AirBnb.Server.App.Persistence.Repositories.Interfaces;

namespace AirBnb.Server.App.Persistence.Repositories;

public class LocationRepository(LocationsDbContext dbContext, ICacheBroker cacheBroker)
    : EntityRepositoryBase<Location, LocationsDbContext>(dbContext, cacheBroker, new CacheEntryOptions()), ILocationRepository
{
    public new IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<IList<Location>> GetAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public new ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    public new ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.UpdateAsync(location, saveChanges, cancellationToken);

    public new ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.CreateAsync(location, saveChanges, cancellationToken);

    public new ValueTask<Location?> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(locationId, saveChanges, cancellationToken);
}