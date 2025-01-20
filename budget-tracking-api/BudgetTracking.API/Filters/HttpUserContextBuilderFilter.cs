using System.Security.Claims;
using BudgetTracking.Application.Repositories.User;
using BudgetTracking.Application.Services;

namespace BudgetTracking.API.Filters;

public class HttpUserContextBuilderFilter(IUserRepository userRepository, IUserContext userContext): IEndpointFilter
{
    private async Task BuildAsync(HttpContext httpContext, CancellationToken ct)
     {
         var principal = httpContext.User;
         var email = principal?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
         var user = await userRepository.GetUserByEmailAsync(email ?? string.Empty, ct);
         userContext.SetCurrentUser(user);
     }

    public async ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
    {
        var httpContext = context.HttpContext;

        if (ShouldBeBuilt(httpContext))
        {
            await BuildAsync(httpContext, CancellationToken.None);
        }
        return await next(context);
    }

    private bool ShouldBeBuilt(HttpContext httpContext)
    {
        var att =  httpContext.GetEndpoint()?.Metadata.GetMetadata<SkipUserContextFilterAttribute>();
        return att == null;
    }
}