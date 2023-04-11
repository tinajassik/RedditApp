using Domain.Models;

namespace RedditApp.LogicInterfaces;

public interface IUserLogic
{

    Task<User> CreateAsync(User user);
    Task<User> ValidateLogin(string username, string password);

}