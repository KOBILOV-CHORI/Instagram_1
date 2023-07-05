using Domain.Dtos.CommentDtos;
using Domain.Wrapper;

namespace Infrastructure.Services.CommentService;

public interface ICommentService
{
    public Task<Responce<GetCommentDto>> AddComment(AddCommentDto comment);
    public Task<Responce<GetCommentDto>> UpdateComment(AddCommentDto comment);
    public Task<Responce<bool>> DeleteComment(int id);
    public Task<Responce<GetCommentDto>> GetCommentById(int id);
    public Task<Responce<List<GetCommentDto>>> GetComments();
}