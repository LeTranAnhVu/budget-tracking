using BudgetTracking.Domain.Models;

namespace BudgetTracking.Application.Services.ExpenseService;

public record ExpenseDto
{
    public int Id { get; set; }

    public double Amount { get; set; }

    public string? Note { get; set; }

    public double? Vat { get; set; }

    public bool IncludedTax { get; set; }

    public int CategoryId { get; set; }

    public DateOnly PaidDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }
}
