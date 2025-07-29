using System.Data;
using HuntAPI.Data;
using HuntAPI.Models;
using Microsoft.EntityFrameworkCore;
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

    public async Task<Pokemon> Delete(int Pokemonid)
    {
        var pokemon = await _context.Pokemons.FindAsync(Pokemonid);
        _context.Pokemons.Remove(pokemon);
        await _context.SaveChangesAsync();
        return pokemon;

       
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public Task<List<Pokemon>> GetAll()
    {
        return _context.Pokemons.ToListAsync();
    }

    public async Task<Pokemon?> GetByID(int id)
    {
        return await _context.Pokemons.FindAsync(id);
    }

    public Task<Item> GetItensbyID()
    {
        throw new NotImplementedException();
    }

    public async Task<Pokemon> Update(Pokemon entity)
    {
        var existing = _context.Pokemons.FindAsync(entity.Id);
        if (existing == null)
        {
            throw new Exception($"{entity.Id} nao existe.");
        }
        _context.Pokemons.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }
}