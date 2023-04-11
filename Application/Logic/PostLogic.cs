using Domain.DTOs;
using Domain.Models;
using RedditApp.DaoInterfaces;
using RedditApp.LogicInterfaces;

namespace RedditApp.Logic;

public class PostLogic : IPostLogic
{

    private IPostDao postDao;
    private IUserDao userDao;

    public PostLogic(IPostDao dao, IUserDao userDao)
    {
        postDao = dao;
        this.userDao = userDao; 
    }

    public async Task<Post> CreateAsync(CreatePostDto dto)
    {
        User? existing = await userDao.GetByUsername(dto.Owner);

        if (existing == null)
        {
            throw new Exception("Cannot create post without an account");
        }

        ValidateData(dto);

        Post toCreate = new Post()
        {
            Owner = existing,
            Title = dto.Title,
            Content = dto.Content
        };

        Post newPost = await postDao.CreateAsync(toCreate);
        return newPost;

    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        return await postDao.GetAsync(); 
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        return await postDao.GetByIdAsync(id);
    }

    public void ValidateData(CreatePostDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new Exception("Title cannot be empty sorry"); 
        }

        if (string.IsNullOrEmpty(dto.Content))
        {
            throw new Exception("You cannot post an empty post bro :)");
        }

        if (dto.Title.Length is > 30 or < 3)
        {
            throw new Exception("I do not agree with the title length");
        }

        switch (dto.Content.Length)
        {
            case < 15:
                throw new Exception("You have to write a little more :)");
            case > 10000:
                throw new Exception("too much text");
        }
    }
}