namespace Domain.Dtos.CommentDtos;

public class CommentBaseDto
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public DateTime CreateDate { get; set; }
}