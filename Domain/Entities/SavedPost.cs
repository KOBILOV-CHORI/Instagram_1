using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class SavedPost
{
    [Key] public int Id { get; set; }
    [ForeignKey("User")] public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("Post")] public int PostId { get; set; }
    public Post Post { get; set; }
    [Required] public DateTime CreateDate { get; set; }
}