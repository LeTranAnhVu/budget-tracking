﻿
using BudgetTracking.API.Filters;
using BudgetTracking.Application.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BudgetTracking.API.Endpoints;

public static class AuthEndpoints
{
    public static RouteGroupBuilder AddAuthEndpoints(this RouteGroupBuilder route)
    {
        var group = route.MapGroup("auth");

        group.MapPost("register", RegisterHandler)
            .WithMetadata(new AllowAnonymousAttribute(), new SkipUserContextFilterAttribute());

        group.MapPost("login", LoginHandler)
            .WithMetadata(new AllowAnonymousAttribute(), new SkipUserContextFilterAttribute());

        return group;
    }

    private static async Task<Ok<string>> LoginHandler(InputUserRegisterDto dto, IAuthService authService, CancellationToken ct)
    {
        var result = await authService.LoginAsync(dto, ct);
        return TypedResults.Ok(result);
    }

    private static async Task<IResult> RegisterHandler(InputUserRegisterDto dto, IAuthService authService, CancellationToken ct)
    {
        await authService.RegisterNewUserAsync(dto, ct);
        return Results.Ok();
    }
}
