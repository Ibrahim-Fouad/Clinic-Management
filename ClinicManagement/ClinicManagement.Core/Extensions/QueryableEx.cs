using System.Linq.Expressions;
using ClinicManagement.Core.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagement.Core.Extensions;

public static class QueryableEx
{
    public static async Task<Paged<T>> PageAsync<TSource, T>(this IQueryable<TSource> queryable, int pageNumber,
        int pageSize,
        CancellationToken cancellationToken = default) where TSource : class where T : class
    {
        queryable.TryGetNonEnumeratedCount(out var total);
        var totalNumber = await queryable.CountAsync(cancellationToken);
        var data = await queryable.Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ProjectToType<T>()
            .ToListAsync(cancellationToken);

        return new Paged<T>(data, pageSize, pageNumber, totalNumber);
    }

    public static IQueryable<T> WhereIf<T>(this IQueryable<T> queryable, bool condition,
        Expression<Func<T, bool>> predicate)
    {
        if (condition)
            return queryable.Where(predicate);
        return queryable;
    }
}