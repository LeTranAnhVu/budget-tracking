using BudgetTracking.Application.Services.ExpenseService;
using BudgetTracking.Domain.Models;

namespace BudgetTracking.Application.Services.CategoryService;

public record CategoryDto
{
    public string Name { get; set; } = null!;

    public string SupCategoryName { get; set; } = null!;

    public string MetaDescription { get; set; } = null!;

    public int SupCategoryId { get; set; }

    public List<ExpenseDto> Expenses { get; set; } = new List<ExpenseDto>();
}
