using System.Linq.Expressions;
using AirBnb.Server.App.Application.Locations.Services;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace AirBnb.Server.App.Infrastructure.Locations.Services;

public class LocationsService(ILocationRepository locationRepository, IValidator<Location> locationValidator) : ILocationsService
{
    public IQueryable<Location> Get(Expression<Func<Location, bool>>? predicate = default, bool asNoTracking = false)
        => locationRepository.Get(predicate, asNoTracking);
    
    public ValueTask<IList<Location>> GetAsync(QuerySpecification<Location> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => locationRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public ValueTask<Location?> GetByIdAsync(Guid locationId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => locationRepository.GetByIdAsync(locationId, asNoTracking, cancellationToken);

    public ValueTask<Location> UpdateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = locationValidator.Validate(location);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationRepository.UpdateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location> CreateAsync(Location location, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = locationValidator.Validate(location);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationRepository.CreateAsync(location, saveChanges, cancellationToken);
    }

    public ValueTask<Location?> DeleteByIdAsync(Guid locationId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => locationRepository.DeleteByIdAsync(locationId, saveChanges, cancellationToken);
}