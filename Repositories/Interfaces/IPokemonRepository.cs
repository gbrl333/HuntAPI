using HuntAPI.Models;
using HuntAPI.Repositories.Interfaces;
using Models;

namespace Repositories;

        
    public interface IPokemonRepository : IRepository<Pokemon>{

        Task<Item> GetItensbyID();    

    }



