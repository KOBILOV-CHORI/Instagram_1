using Domain.Dtos.DirectMessageDtos;

namespace Infrastructure.Services.DirectMessageService;

public interface IDirectMessageService
{
    public Task<GetDirectMessageDto> AddDirectMessage(AddDirectMessageDto comment);
    public Task<GetDirectMessageDto> UpdateDirectMessage(AddDirectMessageDto comment);
    public Task<bool> DeleteDirectMessage(int id);
    public Task<GetDirectMessageDto> GetDirectMessageById(int id);
    public Task<List<GetDirectMessageDto>> GetDirectMessages();
}