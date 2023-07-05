namespace Domain.Dtos.NotificationDtos;

public class NotificationBaseDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Text { get; set; }
    public DateTime CreateDate { get; set; }
    public bool IsRead { get; set; }
}