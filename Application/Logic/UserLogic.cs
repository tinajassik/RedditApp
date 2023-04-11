using Domain.Exceptions;
using Domain.Models;
using RedditApp.DaoInterfaces;
using RedditApp.LogicInterfaces;

namespace RedditApp.Logic;

public class UserLogic : IUserLogic
{

    private readonly IUserDao userDao;

    public UserLogic(IUserDao userDao)
    {
        this.userDao = userDao;
    }
    
    private static void ValidateData(User userToCreate)
    {
        string username = userToCreate.Username;

        if (username.Length < 3)
            throw new InvalidUsernameLengthShort(username.Length.ToString());
        if (username.Length > 15)
            throw new InvalidUsernameLengthLong(username.Length.ToString());
    }

    public async Task<User> CreateAsync(User user)
    {
        User? existing = await userDao.GetByUsername(user.Username);

        if (existing !=null)
        {
            throw new UsernameTakenException(user.Username);
        }
        
        ValidateData(user);
        User toCreate = new User(user.Username, user.Password, user.FirstName, user.LastName);
      

        User newUser = await userDao.CreateAsync(toCreate);

        return newUser; 

    }

    public async Task<User> ValidateLogin(string username, string password)
    {
        User? existingUser = await userDao.GetByUsername(username); 

        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
}