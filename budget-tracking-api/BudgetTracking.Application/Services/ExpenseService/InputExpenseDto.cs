namespace BudgetTracking.Application.Services.ExpenseService;

public record InputExpenseDto
{
    public required double Amount { get; init; }

    public string? Note { get; init; }

    public double? Vat { get; init; }

    public required bool IncludedTax { get; init; }

    public required int CategoryId { get; init; }
}
