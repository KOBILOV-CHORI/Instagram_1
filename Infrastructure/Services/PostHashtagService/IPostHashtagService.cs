using Domain.Dtos.PostHashtagDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.PostHashtagService;

public interface IPostHashtagService
{
    public Task<Responce<GetPostHashtagDto>> AddPostHashtag(AddPostHashtagDto PostHashtag);
    public Task<Responce<GetPostHashtagDto>> UpdatePostHashtag(AddPostHashtagDto PostHashtag);
    public Task<Responce<bool>> DeletePostHashtag(int id);
    public Task<Responce<GetPostHashtagDto>> GetPostHashtagById(int id);
    public Task<Responce<List<GetPostHashtagDto>>> GetPostHashtags();
}