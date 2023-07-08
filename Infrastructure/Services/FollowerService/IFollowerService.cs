using Domain.Dtos.FollowerDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.FollowerService;

public interface IFollowerService
{
    public Task<Responce<GetFollowerDto>> AddFollower(AddFollowerDto comment);
    public Task<Responce<GetFollowerDto>> UpdateFollower(AddFollowerDto comment);
    public Task<Responce<bool>> DeleteFollower(int id);
    public Task<Responce<GetFollowerDto>> GetFollowerById(int id);
    public Task<Responce<List<GetFollowerDto>>> GetFollowers();
}