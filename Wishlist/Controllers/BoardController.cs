using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wishlist.Components;
using Wishlist.Entities;
using Wishlist.Models;

namespace Wishlist.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BoardController : ControllerBase
{
    private readonly WishListDbContext _db;

    public BoardController(WishListDbContext db)
    {
        _db = db;
    }

    [HttpPost("post")]
    public async Task<ActionResult> PostBoard(BoardModel model)
    {
        var board = new Board
        {
            BoardId = Guid.NewGuid(),
            Description = model.Description,
            Name = model.Name
        };
        _db.Boards.Add(board);
        await _db.SaveChangesAsync();
        return CreatedAtAction("GetBoard", new { id = board.BoardId}, board);
    }

    [HttpGet("get/{id}")]
    public async Task<ActionResult<Board>> GetBoard(Guid id)
    {
        var board = await _db.Boards.FindAsync(id);
        if (board == null)
            return NotFound();
        return board;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<IList<Board>>> GetAllBoards()
    {
        return _db.Boards.ToList();
    }


    [HttpPost("add-card/{boardId:guid}")]
    public async Task<ActionResult> AddCard(Guid boardId, [FromBody] CardModel cardModel)
    {
        var board = await _db.Boards.FindAsync(boardId);
        if (board is null)
            return NotFound();
        var card = new Card
        {
            CardId = Guid.NewGuid(),
            BoardId = boardId,
            ImgUri = cardModel.ImgUri,
            Name = cardModel.Name,
            Text = cardModel.Text,
        };
        await _db.Cards.AddAsync(card);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpPost("update-card-coords/")]
    public async Task<ActionResult> UpdateCardCoordinates([FromBody] UpdateCardModel updateCardModel)
    {
        var card = await _db.Cards.FindAsync(updateCardModel.CardId);
        if (card is null)
            return NotFound();
        card.XOffset = updateCardModel.XOffset;
        card.YOffset = updateCardModel.YOffset;
        _db.Cards.Update(card);
        await _db.SaveChangesAsync();
        return Ok();
    }

    [HttpGet("getCards/{boardId:guid}")]
    public async Task<ActionResult<IList<Card>>> GetAllCards(Guid boardId)
    {
        var board = _db.Boards
            .Include(b => b.Cards)
            .FirstOrDefault(b => b.BoardId.Equals(boardId));
        if (board is null)
            return NotFound();
        return board.Cards.ToList();
    }
}
