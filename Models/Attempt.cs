using System.ComponentModel.DataAnnotations.Schema;

namespace DotNet.Models;

public class Attempt
{
    public int Id { get; set; }
    public int M {get; set;}
    public int P {get; set;}

    [ForeignKey(nameof(GameId))]
    public int GameId {get; set;}
    public virtual Game? Game {get; set;}
}

public class Send
{
    public int Id { get; set; }
    public int M {get; set;}
    public int P {get; set;}
    public int GameId {get; set;}
 
}