using Domain.Dtos.PostDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.PostService;

public interface IPostService
{
    public Task<Responce<GetPostDto>> AddPost(AddPostDto Post);
    public Task<Responce<GetPostDto>> UpdatePost(AddPostDto Post);
    public Task<Responce<bool>> DeletePost(int id);
    public Task<Responce<GetPostDto>> GetPostById(int id);
    public Task<Responce<List<GetPostDto>>> GetPosts();
}