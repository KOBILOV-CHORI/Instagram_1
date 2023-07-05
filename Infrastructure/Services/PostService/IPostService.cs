using Domain.Dtos.PostDtos;

namespace Infrastructure.Services.PostService;

public interface IPostService
{
    public Task<GetPostDto> AddPost(AddPostDto Post);
    public Task<GetPostDto> UpdatePost(AddPostDto Post);
    public Task<bool> DeletePost(int id);
    public Task<GetPostDto> GetPostById(int id);
    public Task<List<GetPostDto>> GetPosts();
}