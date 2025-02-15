using BudgetTracking.Application.Services.CategoryService;

namespace BudgetTracking.Application.Services.SupCategoryService;

public record SupCategoryDto
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string MetaDescription { get; set; } = null!;

    public List<CategoryDto> Categories { get; set; } = [];
}
