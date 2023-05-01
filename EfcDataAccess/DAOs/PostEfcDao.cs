using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RedditApp.DaoInterfaces;

namespace EfcDataAccess.DAOs;

public class PostEfcDao: IPostDao
{
    
    private readonly FileContext context;

    public PostEfcDao(FileContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await Task.FromResult(context.Posts.AsEnumerable());
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? post = await context.Posts.Include(post => post.Owner).FirstOrDefaultAsync(post1 => post1.Id == id);
        return post;
    }
}