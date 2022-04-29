using Microsoft.AspNetCore.Mvc;
using Wishlist.Components;
using Wishlist.Entities;
using Wishlist.Models;

namespace Wishlist.Controllers;

[Obsolete("Use BoardController for support multi-paging boards")]
[Route("api/cards/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly WishListDbContext _dbContext;

    public CardController(WishListDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    // здесь была аня
    
    [HttpPost("post")]
    public async Task<ActionResult<Card>> PostCard(CardModel cardModel)
    {
        var card = new Card
        {
            CardId = new Guid(),
            Name = cardModel.Name,
            Text = cardModel.Text,
            ImgUri = cardModel.ImgUri
        };
        
        _dbContext.Cards.Add(card);
        await _dbContext.SaveChangesAsync();
        return CreatedAtAction("GetCard", new { id = card.CardId }, card);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCard(Guid id)
    {
        var card = await _dbContext.Cards.FindAsync(id);
        if (card == null)
            return NotFound();
        return card;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<IList<Card>>> GetAllCards()
    {
        var cards = _dbContext.Cards.ToList();
        return cards;
    }
}