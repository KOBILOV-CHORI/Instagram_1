using Domain.Dtos.LikeDtos;

namespace Infrastructure.Services.LikeService;

public interface ILikeService
{
    public Task<GetLikeDto> AddLike(AddLikeDto Like);
    public Task<GetLikeDto> UpdateLike(AddLikeDto Like);
    public Task<bool> DeleteLike(int id);
    public Task<GetLikeDto> GetLikeById(int id);
    public Task<List<GetLikeDto>> GetLikes();
}