using Domain.Dtos.SavedPostDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.SavedPostService;

public interface ISavedPostService
{
    public Task<Responce<GetSavedPostDto>> AddSavedPost(AddSavedPostDto SavedPost);
    public Task<Responce<GetSavedPostDto>> UpdateSavedPost(AddSavedPostDto SavedPost);
    public Task<Responce<bool>> DeleteSavedPost(int id);
    public Task<Responce<GetSavedPostDto>> GetSavedPostById(int id);
    public Task<Responce<List<GetSavedPostDto>>> GetSavedPosts();
}