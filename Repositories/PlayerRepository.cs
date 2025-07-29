using System.Data;
using HuntAPI.Data;
using HuntAPI.Models;
using Microsoft.EntityFrameworkCore;
using Models;
using Repositories;

public class PlayerRepository : IPlayerRepository
{
    
    private readonly HuntContext _context;
    public PlayerRepository(HuntContext context)
    {
            _context = context;
    }

    public  async Task<Player> Add(Player player)
    {
        
        var entity = await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        
        return entity.Entity;    
    }

    public async Task<Player> Delete(int playerID)
    {
        var ExistingPlayers = await _context.Players.FindAsync(playerID);
        if (ExistingPlayers == null)
          throw new Exception("Player não existe");

        ExistingPlayers.active = false;
        await _context.SaveChangesAsync();
        
        return ExistingPlayers;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Player>> GetAll()
    {
        var ExistingPlayers = await _context.Players.ToListAsync();
        if (ExistingPlayers == null)
        throw new Exception("Player não encontrado");
       return ExistingPlayers;
    }

    public async Task<Player?> GetByID(int id)
    {
        var ExistingPlayers = await _context.Players.FindAsync(id);
        if (ExistingPlayers == null)
        {return null;}  
       return ExistingPlayers;
    }
    public async Task<Player> Update(Player player)
    {
        var existing = await _context.Players.FindAsync(player.Id);
        if (existing == null) throw new KeyNotFoundException("Player não encontrado");

        existing.Name = player.Name ?? existing.Name;
        existing.Clan = player.Clan ?? existing.Clan;
        existing.Disk = player.Disk ?? existing.Disk;

        await _context.SaveChangesAsync();
        return existing;
    
    }


}

