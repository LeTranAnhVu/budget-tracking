namespace BudgetTracking.Application.Services.AuthService;

public record InputUserRegisterDto
{
    public required string Email { get; init; }
    public required string Password { get; init; }
}
