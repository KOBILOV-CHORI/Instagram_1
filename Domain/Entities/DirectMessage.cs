using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class DirectMessage
{
    [Key] public int Id { get; set; }
    [ForeignKey("Sender")] public int SenderId { get; set; }
    public User Sender { get; set; }
    [ForeignKey("Receiver")] public int ReceiverId { get; set; }
    public User Receiver { get; set; }
    [Required] public string Text { get; set; }
    [Required] public DateTime CreateDate { get; set; }
}