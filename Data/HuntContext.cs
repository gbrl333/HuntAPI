using Microsoft.EntityFrameworkCore;
using Models;
namespace Data;

public class HuntContext : DbContext{

    public DbSet<Player> Players { get; set; }

    public DbSet<Spawn> Spawns { get; set; }
    public DbSet<Item> Itens { get; set; }
    public DbSet<Pokemon> Pokemons { get; set; }
    public DbSet<Hunt> Hunts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Hunt.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}