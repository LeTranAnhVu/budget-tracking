namespace BudgetTracking.API.Filters;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
public class SkipUserContextFilterAttribute: Attribute
{
}
