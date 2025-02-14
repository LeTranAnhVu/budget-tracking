
using BudgetTracking.Application.Services.CategoryService;
using BudgetTracking.Application.Services.SupCategoryService;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BudgetTracking.API.Endpoints;

public static class SupCategoryEndpoints
{
    public static RouteGroupBuilder AddSupCategoryEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("sup-categories");

        group.MapGet("", GetHandler);
        group.MapGet("with-transactions", GetAnyWithTransactionsHandler);
        return group;
    }

    private static async Task<Ok<List<SupCategoryDto>>> GetHandler(ISupCategoryService supCategoryService, CancellationToken ct)
    {
        var supCategoryDtos = await supCategoryService.GetAllAsync(ct);
        return TypedResults.Ok(supCategoryDtos);
    }

    private static async Task<Ok<List<SupCategoryDto>>> GetAnyWithTransactionsHandler([FromQuery] int? daysAgo, ISupCategoryService supCategoryService, CancellationToken ct)
    {
        var supCategoryDtos = await supCategoryService.GetAnyWithTransactionsAsync(daysAgo, ct);
        return TypedResults.Ok(supCategoryDtos);
    }
}
