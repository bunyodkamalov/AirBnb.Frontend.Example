using System.Linq.Expressions;
using AirBnb.Server.App.Application.Locations.Services;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Infrastructure.Validators;
using AirBnb.Server.App.Persistence.Repositories.Interfaces;
using FluentValidation;

namespace AirBnb.Server.App.Infrastructure.Locations.Services;

public class LocationCategoryService(ILocationCategoryRepository locationCategoryRepository, IValidator<LocationCategory> validator) : ILocationCategoryService
{
    public IQueryable<LocationCategory> Get(Expression<Func<LocationCategory, bool>>? predicate = default, bool asNoTracking = false)
        => locationCategoryRepository.Get(predicate, asNoTracking);
    
    public ValueTask<IList<LocationCategory>> GetAsync(QuerySpecification<LocationCategory> querySpecification, bool asNoTracking = false,
        CancellationToken cancellationToken = default)
        => locationCategoryRepository.GetAsync(querySpecification, asNoTracking, cancellationToken);

    public ValueTask<LocationCategory?> GetByIdAsync(Guid locationCategoryId, bool asNoTracking = false, CancellationToken cancellationToken = default)
        => locationCategoryRepository.GetByIdAsync(locationCategoryId, asNoTracking, cancellationToken);

    public ValueTask<LocationCategory> UpdateAsync(LocationCategory locationCategory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(locationCategory);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationCategoryRepository.UpdateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory> CreateAsync(LocationCategory locationCategory, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var validationResult = validator.Validate(locationCategory);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        return locationCategoryRepository.CreateAsync(locationCategory, saveChanges, cancellationToken);
    }

    public ValueTask<LocationCategory?> DeleteByIdAsync(Guid locationCategoryId, bool saveChanges = true, CancellationToken cancellationToken = default)
        => locationCategoryRepository.DeleteByIdAsync(locationCategoryId, saveChanges, cancellationToken);
}