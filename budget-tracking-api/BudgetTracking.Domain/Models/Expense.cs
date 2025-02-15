using BudgetTracking.Domain.Models.Common;

namespace BudgetTracking.Domain.Models;

public class Expense : ModelBase, ITrackable
{
    public double Amount { get; set; }

    public string? Note { get; set; }

    public double? Vat { get; set; }

    public bool IncludedTax { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; } = null!;


    public DateOnly PaidDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }
}
