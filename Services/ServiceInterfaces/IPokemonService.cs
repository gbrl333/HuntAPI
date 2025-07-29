using HuntAPI.Models;
using Models;
namespace Services;

public interface IPokemonService
{
    Task<Pokemon> Create(Pokemon pokemon);
    Task<Pokemon?> GetbyID(int id);
    Task<List<Pokemon>> GetAll();
    Task<Pokemon> Update(Pokemon pokemon);
    Task<Pokemon> Delete(int id);
    
    Task<Item> GetItem(int id);
}