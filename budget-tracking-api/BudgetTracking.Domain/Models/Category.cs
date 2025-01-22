using BudgetTracking.Domain.Models.Common;

namespace BudgetTracking.Domain.Models;

public class Category : ModelBase
{
    public string Name { get; set; } = null!;

    public SupCategory SupCategory { get; set; } = null!;

    public int SupCategoryId { get; set; }

    public List<Expense> Expenses { get; set; } = new List<Expense>();
}
