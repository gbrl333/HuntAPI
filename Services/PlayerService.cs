using HuntAPI.Models;
using Models;
using Repositories;
using Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository _repository;
        public PlayerService(IPlayerRepository repository)
    {
        _repository = repository;
    }

    public Task<Player> Create(Player player)
    {
        if (player == null)
            throw new Exception("Player não encontrado");
        return _repository.Add(player);    

    }

    public Task<Player> Delete(int id)
    {
        if (id == 0)
        {
            throw new Exception("Player não encontrado");
        }
        return _repository.Delete(id);
    }
    public Task<List<Player>> GetAll()
    {
        return _repository.GetAll();
    }

    public Task<Player?> GetbyID(int id)
    {
        if (id == 0)
        {
            throw new Exception("id nao encontrado");
        }
        return _repository.GetByID(id);
    }

    public Task<Player> Update(Player player)
    {
        throw new NotImplementedException();
    }
}
