using System.Security.Claims;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    public Task<User> CreateAsync(User user);
    public Task LoginAsync(string username, string password);
    public Task LogoutAsync();
    public Task<ClaimsPrincipal> GetAuthAsync();

    public Action<ClaimsPrincipal> OnAuthStateChanged { get; set; }
    
}