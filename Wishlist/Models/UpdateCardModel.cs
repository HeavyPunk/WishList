using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class UpdateCardModel
{
    [Required]
    public Guid CardId { get; set; }
    [Required]
    public float XOffset { get; set; }
    [Required]
    public float YOffset { get; set; }
}