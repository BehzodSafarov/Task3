namespace Task3.Models;

public class User
{
    public int Id { get; set; }
    public string? Name { get; set; }
    
    public int Step {get; set;}

    public List<GameModel>? NumberModels {get; set;}
}