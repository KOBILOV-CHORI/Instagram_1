using Domain.Dtos.LikeDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.LikeService;

public interface ILikeService
{
    public Task<Responce<GetLikeDto>> AddLike(AddLikeDto Like);
    public Task<Responce<GetLikeDto>> UpdateLike(AddLikeDto Like);
    public Task<Responce<bool>> DeleteLike(int id);
    public Task<Responce<GetLikeDto>> GetLikeById(int id);
    public Task<Responce<List<GetLikeDto>>> GetLikes();
}