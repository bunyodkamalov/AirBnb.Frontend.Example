using AirBnb.Server.App.Domain.Common.Entities;
using AirBnb.Server.App.Domain.Common.Entities.Interfaces;

namespace AirBnb.Server.App.Domain.Entities;

public class LocationCategory : Entity
{
    public string Name { get; set; } = default!;

    public string ImageUrl { get; set; } = default!;
}