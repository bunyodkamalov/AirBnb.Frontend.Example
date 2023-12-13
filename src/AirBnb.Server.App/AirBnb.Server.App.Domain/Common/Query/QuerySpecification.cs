using System.Linq.Expressions;
using AirBnb.Server.App.Domain.Common.Caching;
using AirBnb.Server.App.Domain.Common.Entities.Interfaces;
using AirBnb.Server.App.Domain.Comparers;

namespace AirBnb.Server.App.Domain.Common.Query;

public class QuerySpecification<TEntity>(uint pageSize, uint pageToken) : CacheModel where TEntity : IEntity
{
    public List<Expression<Func<TEntity, bool>>> FilteringOptions { get; } = new();

    public List<(Expression<Func<TEntity, object>> KeySelector, bool isAscending)> OrderingOptions { get; } = new();

    public FilterPagination PaginationOptions { get; set; } = new(pageSize, pageToken);

    public override int GetHashCode()
    {
        var hashCode = new HashCode();

        foreach (var option in OrderingOptions)
            hashCode.Add(option.ToString());

        foreach (var  option in FilteringOptions.Order(new PredicateExpressionComparer<TEntity>()))
            hashCode.Add(option.ToString());
        
        hashCode.Add(PaginationOptions);

        return hashCode.ToHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is QuerySpecification<TEntity> querySpecification && querySpecification.GetHashCode() == GetHashCode();
    }

    public override string CacheKey => $"{typeof(TEntity).Name}_{GetHashCode()}";
}