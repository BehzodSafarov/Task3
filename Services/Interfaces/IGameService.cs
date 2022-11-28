using Task3.Models;

namespace Task3.Services;

public interface IGameService
{
    public void CreateGame(GameModel gameModel);
    public GameModel GetGame(int id);

    public int GetUserStep(int userId, string RandomNumber);

    public List<string> GetAll(int userId, string RandomNumber);
}