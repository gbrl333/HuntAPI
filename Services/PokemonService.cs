using HuntAPI.Models;
using Models;
using Repositories;
using Services;

public class PokemonService : IPokemonService
{

        private readonly IPokemonRepository _repository;
        public PokemonService(IPokemonRepository repository)
    {
        _repository = repository;
    }

    public Task<Pokemon> Create(Pokemon pokemon)
    {
        if (pokemon == null)
        {
            throw new Exception("Pokemon Invalido");
        }

        return  _repository.Add(pokemon);
    }

    public Task<Pokemon> Delete(int id)
    {
        if (id == 0)
        {

        }
       throw new Exception("Pokemon nao encontrado ");
    }

    public Task<List<Pokemon>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon?> GetbyID(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Item> GetItem(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Pokemon> Update(Pokemon pokemon)
    {
        throw new NotImplementedException();
    }
}
