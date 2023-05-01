using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class User
{
    [Key]
    [MaxLength(16), MinLength(3)]
    public string Username { get; set; }
    public string Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public User(string username, string password, string firstName, string lastName)
    {
        Username = username;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }
}