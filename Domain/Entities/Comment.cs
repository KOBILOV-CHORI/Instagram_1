using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Comment
{
    [Key]
    public int Id { get; set; }
    [Required, ForeignKey("Post")]
    public int PostId { get; set; }
    public Post Post { get; set; }
    [Required, ForeignKey("User")]
    public int UserId { get; set; }
    public User User { get; set; }
    [Required]
    public string Text { get; set; }
    [Required]
    public DateTime CreateDate { get; set; }
}