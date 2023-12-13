using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;

namespace AirBnb.Server.App.Persistence.Repositories.Interfaces;

public interface ILocationRepository
{
    IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false);
    
    ValueTask<IList<Location>> GetAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<Location?> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default);
}