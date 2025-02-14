
using BudgetTracking.Application.Services.CategoryService;
using BudgetTracking.Application.Services.SupCategoryService;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetTracking.API.Endpoints;

public static class SupCategoryEndpoints
{
    public static RouteGroupBuilder AddSupCategoryEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("supCategories");

        group.MapGet("", GetHandler);
        return group;
    }

    private static async Task<Ok<List<SupCategoryDto>>> GetHandler(ISupCategoryService supCategoryService, CancellationToken ct)
    {
        var supCategoryDtos = await supCategoryService.GetAllAsync(ct);
        return TypedResults.Ok(supCategoryDtos);
    }
}
