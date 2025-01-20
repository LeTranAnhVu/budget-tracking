namespace BudgetTracking.Application.Exceptions;

public class EntityNotFoundException : Exception
{
    public override string Message { get; }

    public EntityNotFoundException(string entityName)
    {
        Message = $"Entity {entityName} not found.";
    }
    public EntityNotFoundException(string entityName, string withKey)
    {
        Message = $"Entity {entityName} with {withKey} not found.";
    }

    public EntityNotFoundException(string entityName, int withKey)
    {
        Message = $"Entity {entityName} with {withKey} not found.";
    }
}
