using Domain.Models;

namespace RedditApp.DaoInterfaces;

public interface IUserDao
{
    Task<User> CreateAsync(User user);
    Task<User?> GetByUsername(string username);
}