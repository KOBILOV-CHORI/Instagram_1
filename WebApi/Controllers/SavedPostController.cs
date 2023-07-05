using Domain.Dtos.SavedPostDtos;
using Infrastructure.Services.SavedPostService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class SavedPostController : ControllerBase
{
    private readonly SavedPostService _service;

    public SavedPostController(SavedPostService service)
    {
        _service = service;
    }
    [HttpPost("AddSavedPost")]
    public async Task<GetSavedPostDto> AddSavedPost(AddSavedPostDto savedPost)
    {
        return await _service.AddSavedPost(savedPost);
    }
    [HttpPut("UpdateSavedPost")]
    public async Task<GetSavedPostDto> UpdateSavedPost(AddSavedPostDto savedPost)
    {
        return await _service.UpdateSavedPost(savedPost);
    }
    [HttpDelete("DeleteSavedPost")]
    public async Task<bool> DeleteSavedPost(int id)
    {
        return await _service.DeleteSavedPost(id);
    }
    [HttpGet("GetSavedPostById")]
    public async Task<GetSavedPostDto> GetSavedPostById(int id)
    {
        return await _service.GetSavedPostById(id);
    }
    [HttpGet("GetSavedPosts")]
    public async Task<List<GetSavedPostDto>> GetSavedPosts()
    {
        return await _service.GetSavedPosts();
    }
}