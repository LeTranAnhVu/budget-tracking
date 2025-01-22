namespace BudgetTracking.Application.Services.ExpenseService;

public interface IExpenseService
{
    public Task<List<ExpenseDto>> GetAll(CancellationToken ct);
    public Task<ExpenseDto> CreateOne(InputExpenseDto dto, CancellationToken ct);
    
    public Task<ExpenseDto> UpdateOne(InputExpenseDto dto, CancellationToken ct);
    public Task DeleteOne(int id, CancellationToken ct);
}
