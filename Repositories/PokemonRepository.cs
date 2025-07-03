using Data;
using Models;
using Repositories;

public class PokemonRepository : IPokemonRepository
{

    private readonly HuntContext _context;
     public PokemonRepository(HuntContext context)
    {
            _context = context;
    }

    public async Task<Pokemon> Add(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            throw new Exception("Pokemon Invalido");
        }
        var entity = await _context.Pokemons.AddAsync(pokemon);
        await _context.SaveChangesAsync();
        return entity.Entity;
    }

    public Task<Pokemon> Delete(int Pokemonid)
    {
      throw new NotImplementedException();
    }

    public Task<Pokemon> Delete(Pokemon entity)
    {
        throw new NotImplementedException();
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<List<Pokemon>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon?> GetByID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItensbyID()
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> Update(Pokemon entity)
    {
        throw new NotImplementedException();
    }
}