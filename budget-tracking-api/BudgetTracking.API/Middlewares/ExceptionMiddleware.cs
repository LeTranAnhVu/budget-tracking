using BudgetTracking.Application.Exceptions;

namespace BudgetTracking.API.Middlewares;


record ErrorMessage(int StatusCode, string Message);
public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (LoginException e)
        {
            logger.LogError(e, e.Message);
            var publicMessage = "Invalid email or password";

            await SendResponseAsync(context, StatusCodes.Status401Unauthorized, publicMessage);
        }
        catch (EntityNotFoundException e)
        {
            logger.LogError(e, e.Message);
            await SendResponseAsync(context, StatusCodes.Status404NotFound, e.Message);
        }
    }

    private static async Task SendResponseAsync(HttpContext context, int statusCode,string publicMessage)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsJsonAsync(new ErrorMessage(statusCode, publicMessage));
    }
}
