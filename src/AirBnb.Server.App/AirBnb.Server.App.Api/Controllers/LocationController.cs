using AirBnb.Server.App.Api.Dtos.Models;
using AirBnb.Server.App.Application.Locations.Services;
using AirBnb.Server.App.Domain.Common.Query;
using AirBnb.Server.App.Domain.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirBnb.Server.App.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LocationController(ILocationsService locationsService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    public async ValueTask<IActionResult> Get([FromQuery] FilterPagination filterPagination)
    {
        var specification = new QuerySpecification<Location>(filterPagination.PageSize, filterPagination.PageToken);
        var result = await locationsService.GetAsync(specification);

        return result.Any() ? Ok(result) : NotFound();
    }

    [HttpGet("{locationId:guid}")]
    public async ValueTask<IActionResult> GetById([FromRoute] Guid locationId)
    {
        var result = await locationsService.GetByIdAsync(locationId);
        return result is not null ? Ok(result) : NotFound();
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] LocationDto locationDto)
    {
        var result = await locationsService.CreateAsync(mapper.Map<Location>(locationDto));
        return CreatedAtAction(
            nameof(GetById),
            new
            {
                todoId = result.Id
            },
            result
        );
    }

    [HttpPut]
    public async ValueTask<IActionResult> Update([FromBody] LocationDto locationDto)
    {
        var result = await locationsService.UpdateAsync(mapper.Map<Location>(locationDto));
        return Ok(result);
    }

    [HttpDelete("{todoId:guid}")]
    public async ValueTask<IActionResult> Delete([FromRoute] Guid locationId)
    {
        await locationsService.DeleteByIdAsync(locationId);
        return Ok();
    }
}