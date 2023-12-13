using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Caching;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Persistence.Caching;
using AirBnb.Server.App.Persistence.DataContexts;
using AirBnb.Server.App.Persistence.Repositories.Interfaces;

namespace AirBnb.Server.App.Persistence.Repositories;

public class LocationCategoryRepository(LocationsDbContext locationsDbContext, ICacheBroker cacheBroker) : 
    EntityRepositoryBase<LocationCategory, LocationsDbContext>(locationsDbContext, cacheBroker, new CacheEntryOptions()), ILocationCategoryRepository
{
    public new IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
        => base.Get(predicate, asNoTracking);

    public new ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => base.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public new ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => base.GetByIdAsync(locationCategoryId, asNoTracking, cancellationToken);

    public new ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.UpdateAsync(locationCategory, saveChanges, cancellationToken);

    public new ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.CreateAsync(locationCategory, saveChanges, cancellationToken);

    public new ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationCategoryId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => base.DeleteByIdAsync(locationCategoryId, saveChanges, cancellationToken);
}