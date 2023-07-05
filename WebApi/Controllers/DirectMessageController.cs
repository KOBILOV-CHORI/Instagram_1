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
    public async Task<GetDirectMessageDto> AddDirectMessage(AddDirectMessageDto directMessage)
    {
        return await _service.AddDirectMessage(directMessage);
    }
    [HttpPut("UpdateDirectMessage")]
    public async Task<GetDirectMessageDto> UpdateDirectMessage(AddDirectMessageDto directMessage)
    {
        return await _service.UpdateDirectMessage(directMessage);
    }
    [HttpDelete("DeleteDirectMessage")]
    public async Task<bool> DeleteDirectMessage(int id)
    {
        return await _service.DeleteDirectMessage(id);
    }
    [HttpGet("GetDirectMessageById")]
    public async Task<GetDirectMessageDto> GetDirectMessageById(int id)
    {
        return await _service.GetDirectMessageById(id);
    }
    [HttpGet("GetDirectMessages")]
    public async Task<List<GetDirectMessageDto>> GetDirectMessages()
    {
        return await _service.GetDirectMessages();
    }
}