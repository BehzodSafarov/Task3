using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.Models;

public class Game
{
    public int Id { get; set; }
    public string? RandomNumber { get; set; }
    public int Step { get; set; }

    public virtual  List<Attempt>? Attempts {get; set;}
    public int GamerId { get; set; }
    public virtual Gamer? Gamer {get; set;}
}