using AirBnb.Server.App.Domain.Entities;
using AirBnb.Server.App.Persistence.DataContexts;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.App.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask InitializeSeedAsync(this IServiceProvider serviceProvider)
    {
        var locationsDbContext = serviceProvider.GetRequiredService<LocationsDbContext>();

        if (!await locationsDbContext.Locations.AnyAsync())
            await locationsDbContext.SeedLocationsAsync();
        
        if (!await locationsDbContext.LocationCategories.AnyAsync())
            await locationsDbContext.SeedLocationCategoryAsync();
    }

    private static async ValueTask SeedLocationsAsync(this LocationsDbContext locationsDbContext)
    {
        var images = new List<string>
        {
            "https://a0.muscache.com/im/pictures/miso/Hosting-852899544635683289/original/c627f47e-8ca9-4471-90d4-1fd987dd2362.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-40792948/original/f603aac0-729b-41e0-932a-823c27142204.jpeg?im_w=720",
            "https://a0.muscache.com/im/pictures/177ed8a7-557b-480f-8319-4f8330e2c692.jpg?im_w=720",
            "https://a0.muscache.com/im/pictures/miso/Hosting-696847375839509250/original/9686a3bd-dfff-4ae6-bb51-514154308bdb.png?im_w=720",
            "https://a0.muscache.com/im/pictures/d879c12a-9259-4080-847e-faeecfe176d9.jpg?im_w=720"
        };
        var random = new Random();
        
        foreach (var image in images)
        {
            await locationsDbContext.Locations.AddAsync(new Location
            {
                ImageUrl = image,
                Name = "Bujra. India Bujra. India Bujra. India Bujra. India Bujra. India Bujra. IndiaBujra. IndiaBujra. India",
                BuiltYear = random.Next(2010, 2023),
                PricePerNight = random.Next(300, 5000)
            });

            await locationsDbContext.SaveChangesAsync();
        }
    }

    private static async ValueTask SeedLocationCategoryAsync(this LocationsDbContext locationsDbContext)
    {
        var categoryImages = new Dictionary<string, string>();
        categoryImages.Add("Castles","1b6a8b70-a3b6-48b5-88e1-2243d9172c06.jpg");
        categoryImages.Add("Caves",  "4221e293-4770-4ea8-a4fa-9972158d4004.jpg");
        categoryImages.Add("Tropical", "ee9e2a40-ffac-4db9-9080-b351efc3cfc4.jpg");
        categoryImages.Add("Amazing Pools", "3fb523a0-b622-4368-8142-b5e03df7549b.jpg");
        categoryImages.Add("Surfing", "957f8022-dfd7-426c-99fd-77ed792f6d7a.jpg" );
        categoryImages.Add("Tiny Homes", "3271df99-f071-4ecf-9128-eb2d2b1f50f0.jpg");
        categoryImages.Add("Minsus", "48b55f09-f51c-4ff5-b2c6-7f6bd4d1e049.jpg");
        categoryImages.Add("Towers", "d721318f-4752-417d-b4fa-77da3cbc3269.jpg");
        categoryImages.Add("Islands", "8e507f16-4943-4be9-b707-59bd38d56309.jpg");
        categoryImages.Add("Arctic", "8b44f770-7156-4c7b-b4d3-d92549c8652f.jpg");
        categoryImages.Add("OMG!", "c5a4f6fc-c92c-4ae8-87dd-57f1ff1b89a6.jpg");
        categoryImages.Add("Amazing Views", "c5a4f6fc-c92c-4ae8-87dd-57f1ff1b89a6.jpg");
        
        foreach (var category in categoryImages)
        {
            await locationsDbContext.LocationCategories.AddAsync(new LocationCategory()
            {
                Name = category.Key,
                ImageUrl = category.Value
            });
        }

        await locationsDbContext.SaveChangesAsync();
    }

}