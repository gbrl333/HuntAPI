using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Enum;

namespace HuntAPI.Models;
public class Player {

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]    
    public int Id { get; init; } 

    public string? Name { get; set; }

    public Clan? Clan { get; set; } 

    public int? Disk { get; set; }   

    public bool active { get; set; }

    public Player(string name, Clan? clan, int? disk)
    {
        Name = name;
        Clan = clan;
        Disk = disk;
        active = true;
    }

}