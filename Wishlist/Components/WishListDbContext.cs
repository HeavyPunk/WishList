using Microsoft.EntityFrameworkCore;
using Wishlist.Entities;

namespace Wishlist.Components;

public class WishListDbContext : DbContext
{
    public WishListDbContext(DbContextOptions<WishListDbContext> options) : base(options)
    {
        
    }

    public DbSet<Card> Cards { get; set; } = null;
    public DbSet<Board> Boards { get; set; } = null;
}