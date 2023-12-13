using AirBnb.Server.App.Domain.Common.Entities.Interfaces;

namespace AirBnb.Server.App.Domain.Common.Entities;

public class Entity : IEntity
{
    public Guid Id { get; set; }
}