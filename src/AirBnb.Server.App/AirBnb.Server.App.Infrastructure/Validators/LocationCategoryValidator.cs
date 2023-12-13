using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Domain.Enums;
using FluentValidation;

namespace AirBnb.Server.App.Infrastructure.Validators;

public class LocationCategoryValidator : AbstractValidator<LocationCategory>
{
    public LocationCategoryValidator()
    {
        RuleSet(
            EntityEvent.OnCreate.ToString(),
            () =>
            {
                RuleFor(entity => entity.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(64);
                RuleFor(entity => entity.ImageUrl).NotEmpty().NotNull();
            }
            );
        
        RuleSet(
            EntityEvent.OnUpdate.ToString(),
            () =>
            {
                RuleFor(entity => entity.Name).NotEmpty().NotNull().MinimumLength(3).MaximumLength(64);
                RuleFor(entity => entity.ImageUrl).NotEmpty().NotNull();
            }
        );
    }
}