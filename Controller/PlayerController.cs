using HuntAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;
using Services;

namespace Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService _service;

        public PlayerController(IPlayerService repository)
    {
         _service = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
{
    var players = await _service.GetAll();
    return Ok(players);
}

[HttpGet("{id}")]
public async Task<ActionResult<Player>> GetById(int id)
{
    var player = await _service.GetbyID(id);
    if (player == null)
        return NotFound("Jogador não encontrado");

    return Ok(player);
}
[HttpPost]
 public async Task<ActionResult<Player>> Add(Player player)
{
    var novoPlayer = await _service.Create(player);
    return CreatedAtAction(nameof(GetById), new { id = novoPlayer.Id }, novoPlayer);
}
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Player player)
{
    if (id != player.Id)
        return BadRequest("IDs não conferem");

        try
        {
          await _service.Update(player);
          return Ok();
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
          await _service.Delete(id);
          return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
}


}