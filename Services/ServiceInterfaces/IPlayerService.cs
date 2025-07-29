using HuntAPI.Models;
using Models;
namespace Services;
public interface IPlayerService
{
    Task<Player> Create(Player player);
    Task<Player?> GetbyID(int id);
    Task<List<Player>> GetAll();
    Task<Player> Update(Player player);
    Task<Player> Delete(int id);
}