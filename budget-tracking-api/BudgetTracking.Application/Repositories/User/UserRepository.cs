﻿using BudgetTracking.Application.Extensions;

namespace BudgetTracking.Application.Repositories.User;


public interface IUserRepository
{
    public Task<UserRepositoryDto> GetUserByEmailAsync(string email, CancellationToken ct);
}

public class UserRepository(IAppDbContext dbContext): IUserRepository
{
    public async Task<UserRepositoryDto> GetUserByEmailAsync(string email, CancellationToken ct)
    {
        var user = await dbContext.Users.GetOrNotFoundAsync(u => u.Email == email, ct);
        return new UserRepositoryDto(user.Id, user.Email);
    }
}
