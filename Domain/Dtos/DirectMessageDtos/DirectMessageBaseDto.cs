namespace Domain.Dtos.DirectMessageDtos;

public class DirectMessageBaseDto
{
    public int Id { get; set; }
    public int SenderId { get; set; }
    public int ReceiverId { get; set; }
    public string Text { get; set; }
    public DateTime CreateDate { get; set; }   
}