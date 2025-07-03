using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class ItemController : ControllerBase
{
    private readonly IItemRepository _repository ;


        public ItemController(IItemRepository repository)
        {
            _repository = repository;
            
        }
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetAll()
{
    var itens = await _repository.GetAll();
    return Ok(itens);
}
[HttpGet("{id}")]
public async Task<ActionResult<Item>> GetById(int id)
{
    var item = await _repository.GetByID(id);
    if (item == null)
        return NotFound("Jogador não encontrado");

    return Ok(item);
}
[HttpPost]
 public async Task<ActionResult<Item>> Add(Item item)
{
    var novoItem = await _repository.Add(item);
    return CreatedAtAction(nameof(GetById), new { id = item.Id }, novoItem);
}
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Item item)
{
    if (id != item.Id)
        return BadRequest("IDs não conferem");

        try
        {
          await _repository.Update(item);
          return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
}

[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id, Item item)
{
    if (id != item.Id)
        return BadRequest("IDs não conferem");

        try
        {
          await _repository.Delete(id);
          return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
}

}