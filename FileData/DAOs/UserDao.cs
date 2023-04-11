using Domain.Models;
using RedditApp.DaoInterfaces;

namespace FileData.DAOs;

public class UserDao : IUserDao
{

    private readonly FileContext fileContext;

    public UserDao(FileContext fileContext)
    {
        this.fileContext = fileContext; 
    }


    public Task<User> CreateAsync(User user)
    {
        fileContext.Users.Add(user);
        fileContext.SaveChanges();
        return Task.FromResult(user);
    }

    public Task<User?> GetByUsername(string username)
    {
        User? existing = fileContext.Users.FirstOrDefault(u =>
            u.Username.Equals(username, StringComparison.OrdinalIgnoreCase)
        );
        return Task.FromResult(existing);
    }
}