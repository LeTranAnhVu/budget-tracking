using System.Linq.Expressions;
using BudgetTracking.Application.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BudgetTracking.Application.Extensions;

public static class QueryableExtension
{
    public static async Task<T> GetOrNotFoundAsync<T>(this IQueryable<T> dbSet, Expression<Func<T, bool>> predicate, CancellationToken ct)
    {
        var entity = await dbSet.FirstOrDefaultAsync(predicate, ct);
        if (entity is null)
        {
            throw new EntityNotFoundException(typeof(T).ShortDisplayName());
        }

        return entity;
    }
}
