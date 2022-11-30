using DotNet.Models;

namespace DotNet.Repositories;

public interface IGameRepository
{
    public Game Create(Game game);
    public List<Game> GetGames(int gamerId);
    public Game GetGame(int id);
    public Attempt CreateAttempt(Attempt attempt);
    public List<Game> AllGames();
}