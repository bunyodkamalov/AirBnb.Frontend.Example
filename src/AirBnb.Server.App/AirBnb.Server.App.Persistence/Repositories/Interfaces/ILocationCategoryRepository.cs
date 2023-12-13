using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;

namespace AirBnb.Server.App.Persistence.Repositories.Interfaces;

public interface ILocationCategoryRepository
{
    IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false);
    
    ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> UpdateAsync(LocationCategory location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory> CreateAsync(LocationCategory location, bool saveChanges = true, CancellationToken cancellationToken = default);

    ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationCategoryId, bool saveChanges = true, CancellationToken cancellationToken = default);
}