using DotNet.Models;

namespace DotNet.Repositories;


public class GameRepository : IGameRepository
{
    private readonly AppDbContext _context;

    public GameRepository(AppDbContext context)
    {
        _context = context;
    }

    public List<Game> AllGames()
    => _context.Games!.ToList();

    public Game Create(Game game)
    {
        var savedGame = _context.Games?.Add(game);
        _context.SaveChanges();

        return  savedGame!.Entity;
    }

    public Attempt CreateAttempt(Attempt attempt)
    {
       var createdAttempt = _context.Attempts?.Add(attempt);
       _context.SaveChanges();

       return createdAttempt?.Entity;
    }

    public Game GetGame(int id)
    {
        var game = _context.Games?.FirstOrDefault(x => x.Id == id);

        return game!;
    }

    public List<Game> GetGames(int gamerId)
    {
        var games = _context.Games?.Where(x => x.GamerId == gamerId).ToList();

        return games!;
    }
}