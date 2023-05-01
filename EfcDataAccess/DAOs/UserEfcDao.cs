using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RedditApp.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class UserEfcDao : IUserDao
{
    
    private readonly FileContext context;

    public UserEfcDao(FileContext context)
    {
        this.context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        EntityEntry<User> newUser = await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return newUser.Entity;
    }

    public async Task<User?> GetByUsername(string username)
    {
        User? user = await context.Users.FindAsync(username);
        return user;
    }
}