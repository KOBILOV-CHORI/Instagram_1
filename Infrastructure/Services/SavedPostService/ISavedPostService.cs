using Domain.Dtos.SavedPostDtos;

namespace Infrastructure.Services.SavedPostService;

public interface ISavedPostService
{
    public Task<GetSavedPostDto> AddSavedPost(AddSavedPostDto SavedPost);
    public Task<GetSavedPostDto> UpdateSavedPost(AddSavedPostDto SavedPost);
    public Task<bool> DeleteSavedPost(int id);
    public Task<GetSavedPostDto> GetSavedPostById(int id);
    public Task<List<GetSavedPostDto>> GetSavedPosts();
}