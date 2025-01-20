using BudgetTracking.Application.Repositories.User;
using BudgetTracking.Application.Services;

namespace BudgetTracking.API.Services;

public class UserHttpContext: IUserContext
{
    public UserRepositoryDto CurrentUser { get; private set; } = null!;

    public void SetCurrentUser(UserRepositoryDto user)
    {
        CurrentUser = user;
    }
}
