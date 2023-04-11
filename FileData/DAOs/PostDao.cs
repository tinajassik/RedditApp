using Domain.DTOs;
using Domain.Models;
using RedditApp.DaoInterfaces;

namespace FileData.DAOs;

public class PostDao : IPostDao
{

    private readonly FileContext fileContext;

    public PostDao(FileContext fileContext)
    {
        this.fileContext = fileContext;
    }

    public Task<Post> CreateAsync(Post post)
    {
        
        int postId = 1;

        if (fileContext.Posts.Any())
        {
            Console.WriteLine("I was here");
            postId = fileContext.Posts.Max(p => p.Id);
            postId++;
        }

        post.Id = postId;
        fileContext.Posts.Add(post);
        fileContext.SaveChanges();
        return Task.FromResult(post);
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await Task.FromResult(fileContext.Posts.AsEnumerable());
    }

    public Task<Post> GetByIdAsync(int id)
    {
        Post existing = fileContext.Posts.FirstOrDefault(t => t.Id == id)!;
        return Task.FromResult(existing);
    }
}