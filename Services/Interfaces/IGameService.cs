using DotNet.Models;

namespace DotNet.Services;

public interface IGameService
{
    public Game CreateGame(Game game);
    public Game GetGame(int id);
    public List<Game> GetAllGames();
    public Attempt CreateAttempt(Attempt attempt);
    public List<Game> GetGames(int userId);
    public string CreateRandomNumber();
    public int[] ValidateGuessNumber(string number, string insertNumber);

}