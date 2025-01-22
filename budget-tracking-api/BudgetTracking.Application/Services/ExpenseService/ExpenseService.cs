using BudgetTracking.Application.Extensions;
using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Application.Services.ExpenseService;

public class ExpenseService(IAppDbContext dbContext, IUserContext userContext) : IExpenseService
{
    public async Task<List<ExpenseDto>> GetAllAsync(CancellationToken ct)
    {
        var expenses = await dbContext.Expenses
            .Where(e =>
                e.CreatedBy == userContext.Id)
            .ToListAsync(ct);

        return expenses.Select(e => e.ToExpenseDto()).ToList();
    }

    public async Task<ExpenseDto> CreateOneAsync(InputExpenseDto payload, CancellationToken ct)
    {
        var category = await dbContext.Categories.GetOrNotFoundAsync(c => c.Id == payload.CategoryId, ct);
        var expense = new Expense()
        {
            Amount = payload.Amount,
            Note = payload.Note,
            Vat = payload.Vat,
            IncludedTax = payload.IncludedTax,
            Category = category
        };

        dbContext.Expenses.Add(expense);
        await dbContext.SaveChangesAsync(ct);

        return expense.ToExpenseDto();
    }

    public async Task<ExpenseDto> UpdateOneAsync(int id, InputExpenseDto payload, CancellationToken ct)
    {
        var expense = await dbContext.Expenses.GetOrNotFoundAsync(c =>
            c.Id == id
            && c.CreatedBy == userContext.Id, ct);
        var category = await dbContext.Categories.GetOrNotFoundAsync(c => c.Id == payload.CategoryId, ct);
        expense.Amount = payload.Amount;
        expense.Note = payload.Note;
        expense.Vat = payload.Vat;
        expense.IncludedTax = payload.IncludedTax;
        expense.Category = category;

        await dbContext.SaveChangesAsync(ct);
        return expense.ToExpenseDto();
    }

    public async Task DeleteOneAsync(int id, CancellationToken ct)
    {
        var expense = await dbContext.Expenses.GetOrNotFoundAsync(c =>
            c.Id == id
            && c.CreatedBy == userContext.Id, ct);

        dbContext.Expenses.Remove(expense);
        await dbContext.SaveChangesAsync(ct);
    }
}
