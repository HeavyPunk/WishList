using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class BoardModel
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
}