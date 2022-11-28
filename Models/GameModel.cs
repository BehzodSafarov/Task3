namespace Task3.Models;

public class GameModel
{
    public int Id { get; set; }
    public string? PandM { get; set; }
    public string RandomNumber {get; set;} = string.Empty;
    public string? GuessNumber {get; set;}

     public int UserId { get; set; }
     public User? User { get; set; }
}