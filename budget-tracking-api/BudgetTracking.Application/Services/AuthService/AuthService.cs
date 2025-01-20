using System.Security.Cryptography;
using System.Text;
using BudgetTracking.Application.Configs;
using BudgetTracking.Application.Exceptions;
using BudgetTracking.Db;
using BudgetTracking.Domain.Models;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BudgetTracking.Application.Services.AuthService;

public interface IAuthService
{
    public Task RegisterNewUserAsync(InputUserRegisterDto dto, CancellationToken ct);
    public Task<string> LoginAsync(InputUserRegisterDto dto, CancellationToken ct);
}

public class AuthService(AppDbContext context, IOptions<JwtSettings> jwtSettings) : IAuthService
{
    public async Task RegisterNewUserAsync(InputUserRegisterDto dto, CancellationToken ct)
    {
        var secret = jwtSettings.Value.Secret;
        var existingUser = await context.Users.AnyAsync(u => u.Email == dto.Email, ct);
        if (existingUser)
        {
            throw new Exception("Cannot register user.");
        }

        var hashPassword = HashPassword(dto.Password, secret);
        var user = new User()
        {
            Email = dto.Email,
            Password = hashPassword
        };

        context.Users.Add(user);
        await context.SaveChangesAsync(ct);
    }

    public async Task<string> LoginAsync(InputUserRegisterDto dto, CancellationToken ct)
    {
        var secret = jwtSettings.Value.Secret;

        var existingUser = await context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email, ct);
        if (existingUser == null)
        {
            throw new LoginException("User not found");
        }

        var hashedInputPassword = HashPassword(dto.Password, secret);
        if (existingUser.Password != hashedInputPassword)
        {
            throw new LoginException("Incorrect email or password");
        }

        return GenerateJwtToken(existingUser.Email);
    }

    private string GenerateJwtToken(string sub)
    {
        var expiredDays = jwtSettings.Value.ExpiredDays;
        var secret = jwtSettings.Value.Secret;
        var audience = jwtSettings.Value.Audience;
        var issuer = jwtSettings.Value.Issuer;

        var issuedAt = DateTimeOffset.UtcNow;
        var notBeforeAt = issuedAt;
        var expiredAt = issuedAt.AddDays(expiredDays);

        var claims = new List<KeyValuePair<string, object>>()
        {
            new("sub", sub),
            new("nbf", notBeforeAt.ToUnixTimeSeconds()),
            new("exp", expiredAt.ToUnixTimeSeconds()),
            new("iat", issuedAt.ToUnixTimeSeconds()),
            new("iss", issuer),
            new("aud", audience),
        };

        var token = JwtBuilder.Create()
            .WithSecret(secret)
            .WithAlgorithm(new HMACSHA256Algorithm())
            .AddClaims(claims)
            .Encode();

        return token;
    }

    private string HashPassword(string pw, string secret)
    {
        var hash = HMACSHA256.HashData(
            Encoding.UTF8.GetBytes(secret),
            Encoding.UTF8.GetBytes(pw));
        return string.Join("", hash.ToList().Select(c => c.ToString("x2")));
    }
}
