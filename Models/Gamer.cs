namespace DotNet.Models;

public class Gamer
{
    public int Id { get; set; }

    public string? Name { get; set; }
      
    public virtual List<Game>? Games {get; set;}
}