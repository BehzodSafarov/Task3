using Task3.Models;

namespace Task3.Repositories;

public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }
    public void CreateGame(GameModel game)
    {
        _context.GameModels?.Add(game);
        _context.SaveChanges();
    }

    public GameModel GetGame(int userId)
    {
        var game = _context.GameModels!.FirstOrDefault(x => x.UserId == userId);

        return game!;
    }
}