using BudgetTracking.Domain.Models.Common;

namespace BudgetTracking.Domain.Models;

public class SupCategory: ModelBase
{
    public string Name { get; set; } = null!;

    public string MetaDescription { get; set; } = null!;

    // public List<Category> Categories { get; set; } = [];
}