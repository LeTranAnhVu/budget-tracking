using BudgetTracking.Application.Services.SupCategoryService;

namespace BudgetTracking.Application.Services.CategoryService;

public interface ISupCategoryService
{
    public Task<List<SupCategoryDto>> GetAllAsync(CancellationToken ct);
}