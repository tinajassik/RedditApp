using System.Collections;
using Domain.DTOs;
using Domain.Models;

namespace RedditApp.LogicInterfaces;

public interface IPostLogic
{
    Task<Post> CreateAsync(CreatePostDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post> GetByIdAsync(int id); 

}