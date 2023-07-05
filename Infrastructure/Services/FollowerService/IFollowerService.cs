using Domain.Dtos.FollowerDtos;

namespace Infrastructure.Services.FollowerService;

public interface IFollowerService
{
    public Task<GetFollowerDto> AddFollower(AddFollowerDto comment);
    public Task<GetFollowerDto> UpdateFollower(AddFollowerDto comment);
    public Task<bool> DeleteFollower(int id);
    public Task<GetFollowerDto> GetFollowerById(int id);
    public Task<List<GetFollowerDto>> GetFollowers();
}