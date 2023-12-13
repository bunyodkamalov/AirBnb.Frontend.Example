using AirBnb.Server.App.Api.Dtos.Models;
using AirBnb.Server.App.Domain.Entities;
using AutoMapper;

namespace AirBnb.Server.App.Api.Mappers;

public class LocationMapper : Profile
{
    public LocationMapper()
    {
        CreateMap<LocationDto, Location>().ReverseMap();
    }
}