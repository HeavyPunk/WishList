using Microsoft.EntityFrameworkCore;
using Wishlist.Entities;

namespace Wishlist.Components;

public class CardDB : DbContext
{
    public CardDB(DbContextOptions<CardDB> options) : base(options)
    {
        
    }

    public DbSet<Card> Cards { get; set; } = null;
}