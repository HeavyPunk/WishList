using System.ComponentModel.DataAnnotations;

namespace Wishlist.Entities;

public class Card
{
    [Key]
    public Guid CardId { get; set; }
    public Guid BoardId { get; set; }
    public string Name { get; set; }
    public string Text { get; set; }
    public string ImgUri { get; set; }
    public float XOffset { get; set; }
    public float YOffset { get; set; }
}