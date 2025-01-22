using BudgetTracking.Domain.Models;

namespace BudgetTracking.Application.Services.ExpenseService;

public static class ExpenseExtension
{
    public static ExpenseDto ToExpenseDto(this Expense expense)
    {
        return new ExpenseDto()
        {
            Id = expense.Id,
            Amount = expense.Amount,
            Note = expense.Note,
            Vat = expense.Vat,
            IncludedTax = expense.IncludedTax,
            CategoryId = expense.CategoryId,
            CreatedBy = expense.CreatedBy,
            CreatedAt = expense.CreatedAt,
            UpdatedAt = expense.UpdatedAt,
            UpdatedBy = expense.UpdatedBy,
        };
    }
}
