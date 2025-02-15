using BudgetTracking.Application.Services.CategoryService;
using BudgetTracking.Application.Services.ExpenseService;
using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Application.Services.SupCategoryService;

public class SupCategoryService(IUserContext userContext, IAppDbContext dbContext) : ISupCategoryService
{
    public async Task<List<SupCategoryDto>> GetAllAsync(CancellationToken ct)
    {
        var supCategories = await dbContext.SupCategories
            .Include(c => c.Categories)
            .ToListAsync(ct);

        return supCategories.Select(Map).ToList();
    }

    public async Task<List<SupCategoryDto>> GetAnyWithTransactionsAsync(int? daysAgo, CancellationToken ct)
    {
        var queryable = dbContext.SupCategories.AsQueryable();


        if (daysAgo.HasValue)
        {
            var dateAgos = DateOnly.FromDateTime(DateTime.Now).AddDays(0 - daysAgo ?? 0);

            queryable = queryable
                .Include(c => c.Categories)
                .ThenInclude(c => c.Expenses.Where(ex => ex.PaidDate >= dateAgos));
        }
        else
        {
            queryable = queryable
                .Include(c => c.Categories)
                .ThenInclude(c => c.Expenses);
        }

        var supCategories = await queryable.ToListAsync(ct);
        return supCategories.Select(Map).ToList();
    }

    public SupCategoryDto Map(SupCategory supCategory) => new SupCategoryDto()
    {
        Id = supCategory.Id,
        Categories = supCategory.Categories.Select(cat => cat.ToCategoryDto()).ToList(),
        Name = supCategory.Name,
        MetaDescription = supCategory.MetaDescription,
    };
}
