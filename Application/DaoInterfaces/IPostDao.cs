using Domain.DTOs;
using Domain.Models;

namespace RedditApp.DaoInterfaces;

public interface IPostDao
{
    Task<Post> CreateAsync(Post post);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post?> GetByIdAsync(int id); 
}