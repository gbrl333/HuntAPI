using Models;

namespace Repositories;

        
    public interface IPokemonRepository : IRepository<Pokemon>{

        Task<Item> GetItensbyID();    

    }



