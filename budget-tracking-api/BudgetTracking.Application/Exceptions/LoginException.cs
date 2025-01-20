namespace BudgetTracking.Application.Exceptions;

public class LoginException(string internalMessage) : Exception
{
    public override string Message { get; } = internalMessage;
}
