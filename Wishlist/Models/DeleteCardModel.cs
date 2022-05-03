using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class DeleteCardModel
{
    [Required]
    public Guid BoardId { get; set; }
    [Required]
    public Guid CardId { get; set; }
}