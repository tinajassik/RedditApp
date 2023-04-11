using Domain.Models;

namespace Domain.DTOs;

public class CreatePostDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string Owner { get; set; }
}