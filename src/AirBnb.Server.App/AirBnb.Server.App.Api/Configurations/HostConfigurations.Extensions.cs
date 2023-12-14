using System.Reflection;
using AirBnb.Server.App.Api.Data;
using AirBnb.Server.App.Application.Locations.Services;
using AirBnb.Server.App.Infrastructure.Locations.Caching;
using AirBnb.Server.App.Infrastructure.Locations.Services;
using AirBnb.Server.App.Infrastructure.Locations.Settings;
using AirBnb.Server.App.Persistence.Caching;
using AirBnb.Server.App.Persistence.DataContexts;
using AirBnb.Server.App.Persistence.Repositories;
using AirBnb.Server.App.Persistence.Repositories.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.App.Api.Configurations;

public static partial class HostConfigurations
{
    
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfigurations()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    {

        builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));
        
        builder.Services.AddStackExchangeRedisCache(
            options =>
            {
                options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
                options.InstanceName = "AirBnb.Frontend.Example";
            });
        
        builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheService>();
        
        return builder;
    }
    
    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        builder.Services.AddValidatorsFromAssemblies(Assemblies);

        return builder;
    }
    
    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }
    
    private static async ValueTask<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var serviceScope = app.Services.CreateScope();
        await serviceScope.ServiceProvider.InitializeSeedAsync();
        
        return app;
    }
    
    private static WebApplicationBuilder AddLocationsInfrastructure(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<LocationsDbContext>(
            options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        builder.Services.Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));
        
        builder.Services.AddScoped<ILocationsService, LocationsService>();
        builder.Services.AddScoped<ILocationCategoryService, LocationCategoryService>();
        
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
        builder.Services.AddScoped<ILocationCategoryRepository, LocationCategoryRepository>();
        
        return builder;
    }
    
    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers().AddNewtonsoftJson();

        return builder;
    }

    private static WebApplicationBuilder AddCors(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => { options.AddDefaultPolicy(policyBuilder => { policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }); }
        );

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        return app;
    }
}