
using BudgetTracking.Application.Services.CategoryService;
using BudgetTracking.Application.Services.SupCategoryService;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetTracking.API.Endpoints;

public static class CategoryEndpoints
{
    public static RouteGroupBuilder AddCategoryEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("categories");

        group.MapGet("", GetHandler);
        return group;
    }

    private static async Task<Ok<List<CategoryDto>>> GetHandler(ICategoryService categoryService, CancellationToken ct)
    {
        var categories = await categoryService.GetAllAsync(ct);
        return TypedResults.Ok(categories);
    }
}
