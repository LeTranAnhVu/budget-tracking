using BudgetTracking.Domain.Models;

namespace BudgetTracking.Application.Services.ExpenseService;

public interface IExpenseService
{
    public Task<List<ExpenseDto>> GetAllAsync(FilterExpenseDto dto, CancellationToken ct);

    public Task<ExpenseDto> GetOneAsync(int id, CancellationToken ct);

    public Task<ExpenseDto> CreateOneAsync(InputExpenseDto dto, CancellationToken ct);

    public Task<ExpenseDto> UpdateOneAsync(int id, InputExpenseDto dto, CancellationToken ct);
    public Task DeleteOneAsync(int id, CancellationToken ct);
}
