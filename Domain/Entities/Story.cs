using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Story
{
    [Key] public int Id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; }
    [Required] public string Media { get; set; }
    public DateTime ExpirationDate { get; set; }
}