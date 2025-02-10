using BudgetTracking.Application.Services.ExpenseService;
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

        return categories.Select(Map).ToList();
    }

    public CategoryDto Map(Category category) => new CategoryDto()
    {
        Id = category.Id,
        Expenses = category.Expenses.Select(ex => ex.ToExpenseDto()).ToList(),
        Name = category.Name,
        SupCategoryName = category.SupCategory.Name,
        MetaDescription = category.SupCategory.MetaDescription,
        SupCategoryId = category.SupCategoryId,
    };
}
