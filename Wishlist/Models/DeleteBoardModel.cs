using System.ComponentModel.DataAnnotations;

namespace Wishlist.Models;

public class DeleteBoardModel
{
    [Required]
    public Guid BoardId { get; set; }
}