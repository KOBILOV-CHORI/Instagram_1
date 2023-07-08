using Domain.Dtos.DirectMessageDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.DirectMessageService;

public interface IDirectMessageService
{
    public Task<Responce<GetDirectMessageDto>> AddDirectMessage(AddDirectMessageDto comment);
    public Task<Responce<GetDirectMessageDto>> UpdateDirectMessage(AddDirectMessageDto comment);
    public Task<Responce<bool>> DeleteDirectMessage(int id);
    public Task<Responce<GetDirectMessageDto>> GetDirectMessageById(int id);
    public Task<Responce<List<GetDirectMessageDto>>> GetDirectMessages();
}