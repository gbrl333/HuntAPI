using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Models;

namespace HuntAPI.Models;
public class Hunt {
    
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; } 

    public Spawn? Spawn { get; set; }
    public Player? Player { get; set; }

    public int PokemonKill { get; set; }

    public int Hours { get; set; }

    public int QtyShiny { get; set; }

    public int QtyCrystal { get; set; }
}