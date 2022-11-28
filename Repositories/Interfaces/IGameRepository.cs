using Task3.Models;

namespace Task3.Repositories;

public interface IGameRepository
{
    public void CreateGame(GameModel game);

    public GameModel GetGame(int userId);
}