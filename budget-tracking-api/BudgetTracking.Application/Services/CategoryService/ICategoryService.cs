using BudgetTracking.Application.Services.SupCategoryService;

namespace BudgetTracking.Application.Services.CategoryService;

public interface ICategoryService
{
    public Task<List<CategoryDto>> GetAllAsync(CancellationToken ct);
}