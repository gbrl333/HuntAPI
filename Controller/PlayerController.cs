using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerRepository _repository;

        public PlayerController(IPlayerRepository repository)
    {
         _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
{
    var players = await _repository.GetAll();
    return Ok(players);
}

[HttpGet("{id}")]
public async Task<ActionResult<Player>> GetById(int id)
{
    var player = await _repository.GetByID(id);
    if (player == null)
        return NotFound("Jogador não encontrado");

    return Ok(player);
}
[HttpPost]
 public async Task<ActionResult<Player>> Add(Player player)
{
    var novoPlayer = await _repository.Add(player);
    return CreatedAtAction(nameof(GetById), new { id = novoPlayer.Id }, novoPlayer);
}
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Player player)
{
    if (id != player.Id)
        return BadRequest("IDs não conferem");

        try
        {
          await _repository.Update(player);
          return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
}

[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id, Player player)
{
    if (id != player.Id)
        return BadRequest("IDs não conferem");

        try
        {
          await _repository.Delete(player);
          return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
}


}