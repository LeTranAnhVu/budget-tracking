using BudgetTracking.Application.Repositories.User;

namespace BudgetTracking.Application.Services;

public interface IUserContext
{
    public int Id => CurrentUser.Id;
    public string Email => CurrentUser.Email;
    public UserRepositoryDto CurrentUser { get; }

    public void SetCurrentUser(UserRepositoryDto user);
}
