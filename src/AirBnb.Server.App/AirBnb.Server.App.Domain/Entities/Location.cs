using AirBnb.Server.App.Domain.Common.Entities;

namespace AirBnb.Server.App.Domain.Entities;

public class Location : Entity
{
    public string ImageUrl { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public int BuiltYear { get; set; }
    
    public int PricePerNight { get; set; }
}