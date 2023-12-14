namespace AirBnb.Server.App.Api.Configurations;

public static partial class HostConfigurations
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddLocationsInfrastructure()
            .AddCors()
            .AddCaching()
            .AddExposers()
            .AddDevTools()
            .AddMappers()
            .AddValidators();
        return new (builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.SeedDataAsync();
        app.UseCors();
        app.UseExposers().UseDevTools().UseStaticFiles();
        
        return app;
    }
}