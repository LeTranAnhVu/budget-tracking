using Microsoft.Extensions.Options;

namespace BudgetTracking.Application.Configs;

public class JwtSettings
{
    public required string Secret { get; init; }
    public required int ExpiredDays { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}
