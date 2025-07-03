using Data;
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
        if (player == null)
            throw new Exception("Player não encontrado");

        var entity = await _context.Players.AddAsync(player);
        await _context.SaveChangesAsync();
        
        return entity.Entity;    
    }

    public async Task<Player> Delete(int playerID)
    {
        var ExistingPlayers = await _context.Players.FindAsync(playerID);
        if (ExistingPlayers == null)
          throw new Exception("Player não encontrado");

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
        var ExistingPlayers = await _context.Players.FindAsync(player.Id);
          if (ExistingPlayers == null)
            throw new Exception("Player não encontrado");

            
         if(player.Clan.HasValue)   
            ExistingPlayers.Clan = player.Clan;
         if(!string.IsNullOrWhiteSpace(player.Name))   
            ExistingPlayers.Name = player.Name;
        if(player.Disk.HasValue)   
            ExistingPlayers.Disk = player.Disk;
        await _context.SaveChangesAsync();

        return ExistingPlayers;
    
    }


}

