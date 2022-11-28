using Task3.Models;
using Task3.Repositories;

namespace Task3.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly AppDbContext _context;

    public GameService(IGameRepository repository, AppDbContext context)
    {
        _repository = repository;
        _context = context;
    }

    public void CreateGame(GameModel gameModel)
    {
        _repository.CreateGame(gameModel);
    }

    public List<string> GetAll(int userId, string RandomNumber)
    {
        List<string> all = new List<string>();
         var gesses = _context.GameModels!.Where(x => x
        .RandomNumber == RandomNumber && x.UserId == userId).ToList();

        foreach (var item in gesses)
        {
            all.Add(item.GuessNumber!+""+item.PandM);
        }

        return all;
    }

    public GameModel GetGame(int id)
    {
        var game = _repository.GetGame(id);

        return game;
    }

    public int GetUserStep(int userId, string RandomNumber)
    {
        var count = _context.GameModels!.Where(x => x
        .RandomNumber == RandomNumber && x.UserId == userId).ToList().Count();

        return count;
    }
}