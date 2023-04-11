using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task<Post> CreateAsync(CreatePostDto dto);
    Task<IEnumerable<Post>> GetAsync();
    Task<Post> GetByIdAsync(int id); 
}