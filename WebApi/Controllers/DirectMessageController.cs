using Domain.Dtos.DirectMessageDtos;
using Infrastructure.Services.DirectMessageService;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class DirectMessageController : ControllerBase
{
    private readonly DIrectMessageService _service;

    public DirectMessageController(DIrectMessageService service)
    {
        _service = service;
    }
    [HttpPost("AddDirectMessage")]
    public async Task<IActionResult> AddDirectMessage(AddDirectMessageDto directMessage)
    {
        var result = await _service.AddDirectMessage(directMessage);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpPut("UpdateDirectMessage")]
    public async Task<IActionResult> UpdateDirectMessage(AddDirectMessageDto directMessage)
    {
        var result = await _service.UpdateDirectMessage(directMessage);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpDelete("DeleteDirectMessage")]
    public async Task<IActionResult> DeleteDirectMessage(int id)
    {
        var result = await _service.DeleteDirectMessage(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetDirectMessageById")]
    public async Task<IActionResult> GetDirectMessageById(int id)
    {
        var result = await _service.GetDirectMessageById(id);
        return StatusCode((int)result.StatusCode, result);
    }
    [HttpGet("GetDirectMessages")]
    public async Task<IActionResult> GetDirectMessages()
    {
        var result = await _service.GetDirectMessages();
        return StatusCode((int)result.StatusCode, result);
    }
}