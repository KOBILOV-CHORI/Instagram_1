using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class PostHashtag
{
    [Key] public int Id { get; set; }
    [ForeignKey("Post")] public int PostId { get; set; }
    public Post Post { get; set; }
    [ForeignKey("Hashtag")] public int HashtagId { get; set; }
    public Hashtag Hashtag { get; set; }
}