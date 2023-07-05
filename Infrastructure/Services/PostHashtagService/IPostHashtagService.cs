using Domain.Dtos.PostHashtagDtos;

namespace Infrastructure.Services.PostHashtagService;

public interface IPostHashtagService
{
    public Task<GetPostHashtagDto> AddPostHashtag(AddPostHashtagDto PostHashtag);
    public Task<GetPostHashtagDto> UpdatePostHashtag(AddPostHashtagDto PostHashtag);
    public Task<bool> DeletePostHashtag(int id);
    public Task<GetPostHashtagDto> GetPostHashtagById(int id);
    public Task<List<GetPostHashtagDto>> GetPostHashtags();
}