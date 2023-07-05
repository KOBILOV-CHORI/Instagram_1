using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Notification
{
    [Key] public int Id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; }
    [Required] public string Text { get; set; }
    [Required] public DateTime CreateDate { get; set; }
    public bool IsRead { get; set; }
}