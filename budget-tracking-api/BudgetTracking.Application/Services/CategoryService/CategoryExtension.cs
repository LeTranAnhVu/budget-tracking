using BudgetTracking.Application.Services.ExpenseService;
using BudgetTracking.Domain.Models;

namespace BudgetTracking.Application.Services.CategoryService;

public static class CategoryExtension
{
    public static CategoryDto ToCategoryDto(this Category category)
    {
        return new CategoryDto()
        {
            Id = category.Id,
            Expenses = category.Expenses.Select(ex => ex.ToExpenseDto()).ToList(),
            Name = category.Name,
            SupCategoryName = category.SupCategory.Name,
            MetaDescription = category.SupCategory.MetaDescription,
            SupCategoryId = category.SupCategoryId,
        };
    }
}
