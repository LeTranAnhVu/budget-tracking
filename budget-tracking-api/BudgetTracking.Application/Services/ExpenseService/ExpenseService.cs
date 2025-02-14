using BudgetTracking.Application.Extensions;
using BudgetTracking.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetTracking.Application.Services.ExpenseService;

public class ExpenseService(IAppDbContext dbContext, IUserContext userContext) : IExpenseService
{
    public async Task<List<ExpenseDto>> GetAllAsync(FilterExpenseDto filterDto, CancellationToken ct)
    {
        var daysAgo = filterDto.DaysAgo ?? 0;
        var queryable = dbContext.Expenses.Include(e => e.Category).AsQueryable();

        if (daysAgo != 0)
        {
            var dateAgos = DateOnly.FromDateTime(DateTime.Now).AddDays(0 - daysAgo);
            queryable = queryable.Where(e =>
                e.CreatedBy == userContext.Id && e.PaidDate >= dateAgos);
        }

        if (filterDto.SupCategoryId.HasValue)
        {
            queryable = queryable.Where(e => e.Category.SupCategoryId == filterDto.SupCategoryId);
        }

        var expenses = await queryable
            .OrderByDescending(e => e.PaidDate)
            .ToListAsync(ct);

        return expenses.Select(e => e.ToExpenseDto()).ToList();
    }

    public async Task<ExpenseDto> GetOneAsync(int id, CancellationToken ct)
    {
        var expense = await dbContext.Expenses.GetOrNotFoundAsync(e => e.Id == id && e.CreatedBy == userContext.Id, ct);
        return expense.ToExpenseDto();
    }

    public async Task<ExpenseDto> CreateOneAsync(InputExpenseDto payload, CancellationToken ct)
    {
        var category = await dbContext.Categories.GetOrNotFoundAsync(c => c.Id == payload.CategoryId, ct);
        var expense = new Expense()
        {
            Amount = payload.Amount,
            Note = payload.Note,
            Vat = payload.Vat,
            PaidDate = payload.PaidDate,
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
        expense.PaidDate = payload.PaidDate;
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
