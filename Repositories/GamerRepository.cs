using DotNet.Models;

namespace DotNet.Repositories;


public class GamerRepository : IGamerRepository
{
    private readonly AppDbContext _context;

    public GamerRepository(AppDbContext context)
    {
        _context = context;
    }
    public Gamer Create(Gamer gamer)
    {
        var createdGamer = _context.Gamers?.Add(gamer);
        _context.SaveChanges();

        return createdGamer!.Entity;
    }

    public Gamer GetGamer(string name)
    {
        var gamer = _context.Gamers?.FirstOrDefault(x => x.Name == name)??new Gamer();
        
        return gamer;
    }

    public List<Gamer> GetGamers()
     => _context.Gamers!.ToList();
}