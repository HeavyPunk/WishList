using System.ComponentModel.DataAnnotations;

namespace Wishlist.Entities;

public class Board
{
    [Key]
    public Guid BoardId { get; set; }
    public IList<Card> Cards { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}