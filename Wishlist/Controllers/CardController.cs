using Microsoft.AspNetCore.Mvc;
using Wishlist.Components;
using Wishlist.Entities;
using Wishlist.Models;

namespace Wishlist.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CardController : ControllerBase
{
    private readonly CardDB _db;

    public CardController(CardDB db)
    {
        _db = db;
    }
    
    [HttpPost("post")]
    public async Task<ActionResult<Card>> PostCard(CardModel cardModel)
    {
        var card = new Card
        {
            Id = new Guid(),
            Name = cardModel.Name,
            Text = cardModel.Text,
        };
        
        _db.Cards.Add(card);
        await _db.SaveChangesAsync();
        return CreatedAtAction("GetCard", new { id = card.Id }, card);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Card>> GetCard(Guid id)
    {
        var card = await _db.Cards.FindAsync(id);
        if (card == null)
            return NotFound();
        return card;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<IList<Card>>> GetAllCards()
    {
        var cards = _db.Cards.ToList();
        return cards;
    }
}