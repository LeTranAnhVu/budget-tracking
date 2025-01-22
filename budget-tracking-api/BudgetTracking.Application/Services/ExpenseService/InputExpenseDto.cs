namespace BudgetTracking.Application.Services.ExpenseService;

public record InputExpenseDto
{
    public double Amount { get; init; }

    public string? Note { get; init; }

    public double? Vat { get; init; }

    public bool IncludedTax { get; init; }

    public int CategoryId { get; init; }
}
