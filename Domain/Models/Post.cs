using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class Post
{

    [Required]
    public string Title { get; private set; }
    public string Content { get; set; }
    public User Owner { get; private set; }
    [Key]
    public int Id { get; set; }

    public Post(User owner, string title)
    {
        Title = title;
        Owner =  owner; 
    }

    private Post()
    {
    }



}