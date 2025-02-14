
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
        group.MapGet("withTransactions", GetAnyWithTransactionsHandler);
        return group;
    }

    private static async Task<Ok<List<SupCategoryDto>>> GetHandler(ISupCategoryService supCategoryService, CancellationToken ct)
    {
        var supCategoryDtos = await supCategoryService.GetAllAsync(ct);
        return TypedResults.Ok(supCategoryDtos);
    }

    private static async Task<Ok<List<SupCategoryDto>>> GetAnyWithTransactionsHandler(ISupCategoryService supCategoryService, CancellationToken ct)
    {
        var supCategoryDtos = await supCategoryService.GetAnyWithTransactionsAsync(ct);
        return TypedResults.Ok(supCategoryDtos);
    }
}
