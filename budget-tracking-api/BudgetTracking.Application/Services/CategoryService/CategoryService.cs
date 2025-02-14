using BudgetTracking.Application.Services.ExpenseService;
using BudgetTracking.Application.Services.SupCategoryService;
using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Application.Services.CategoryService;

public class CategoryService(IUserContext userContext, IAppDbContext dbContext) : ICategoryService
{
    public async Task<List<CategoryDto>> GetAllAsync(CancellationToken ct)
    {
        var categories = await dbContext.Categories
            .Include(c => c.SupCategory)
            .Include(c => c.Expenses)
            .ToListAsync(ct);

        return categories.Select(cat => cat.ToCategoryDto()).ToList();
    }
}
