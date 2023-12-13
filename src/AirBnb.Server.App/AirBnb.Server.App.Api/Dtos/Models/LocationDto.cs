namespace AirBnb.Server.App.Api.Dtos.Models;

public class LocationDto
{
    public Guid Id { get; set; } = default!;
    
    public string ImageUrl { get; set; } = default!;

    public string Name { get; set; } = default!;
    
    public int BuiltYear { get; set; }
    
    public int PricePerNight { get; set; }
}