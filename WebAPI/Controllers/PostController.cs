using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RedditApp.LogicInterfaces;

namespace WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class PostController : ControllerBase
{
    private readonly IPostLogic postLogic;

    public PostController(IPostLogic postLogic)
    {
        this.postLogic = postLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Post>> CreateAsync(CreatePostDto dto)
    {
        try
        {
            Post post = await postLogic.CreateAsync(dto);
            return Created($"/posts/{post.Title}", post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(400, e.Message);
        }
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Post>>> GetAsync()
    {
        try
        {
            var posts = await postLogic.GetAsync();
            return Ok(posts); 
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(400, e.Message);
        }
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Post>> GetByIdAsync([FromRoute] int id)
    {
        
        try
        {
            Post result = await postLogic.GetByIdAsync(id);
            return Ok(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
        
    }


}