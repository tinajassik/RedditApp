namespace Domain.Models;

public class Post
{

    public string Title { get; set; }
    public string Content { get; set; }
    public User Owner { get; set; }
    public int Id { get; set; }


}