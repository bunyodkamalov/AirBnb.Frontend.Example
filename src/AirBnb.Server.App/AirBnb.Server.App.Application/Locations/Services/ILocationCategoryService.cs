using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;

namespace AirBnb.Server.App.Application.Locations.Services;

public interface ILocationCategoryService 
{
    IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false);
    
    ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> UpdateAsync(LocationCategory location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> CreateAsync(LocationCategory location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default);
}