
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetTracking.API.Endpoints;

public static class AuthEndpoints
{
    public static RouteGroupBuilder AddAuthEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("auth");
        group.MapPost("register", RegisterHandler);
        group.MapPost("login", LoginHandler);

        return group;
    }

    private static Task LoginHandler(HttpContext context, CancellationToken ct)
    {
        throw new NotImplementedException();
    }

    private static async Task<IResult> RegisterHandler(HttpContext context, CancellationToken ct)
    {
        await Task.Delay(200);
        return TypedResults.Ok("sdkjfd");
    }
}
