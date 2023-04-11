using System.Net.Http.Json;
using System.Text.Json;
using Domain.DTOs;
using Domain.Models;
using HttpClients.ClientInterfaces;

namespace HttpClients.Implementations;

public class PostHttpClient : IPostService

{
    
    private readonly HttpClient client;
    
    public PostHttpClient(HttpClient client)
    {
        this.client = client;
    }
    public async Task<Post> CreateAsync(CreatePostDto dto)
    {
        
        HttpResponseMessage response = await client.PostAsJsonAsync("/post", dto);
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        Post post = JsonSerializer.Deserialize<Post>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
        
    }

    public async Task<IEnumerable<Post>> GetAsync()
    {
        
        HttpResponseMessage response = await client.GetAsync("/post");
        string result = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(result);
        }

        IEnumerable<Post> posts = JsonSerializer.Deserialize<IEnumerable<Post>>(result, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
        
    }

    public async Task<Post> GetByIdAsync(int id)
    {
        HttpResponseMessage responseMessage = await client.GetAsync($"/post/{id}");
        string content = await responseMessage.Content.ReadAsStringAsync();

        if (!responseMessage.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        Post post = JsonSerializer.Deserialize<Post>(content,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            })!;
        
        return post; 
    }
    
    
}