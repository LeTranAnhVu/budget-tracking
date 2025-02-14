namespace BudgetTracking.Application.Services.SupCategoryService;

public interface ISupCategoryService
{
    public Task<List<SupCategoryDto>> GetAllAsync(CancellationToken ct);
    public Task<List<SupCategoryDto>> GetAnyWithTransactionsAsync(int? daysAgo, CancellationToken ct);
}