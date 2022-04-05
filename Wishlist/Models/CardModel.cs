using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class CardModel
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Text { get; set; }
}