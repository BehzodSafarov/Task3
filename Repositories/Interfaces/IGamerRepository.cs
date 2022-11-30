using DotNet.Models;

namespace DotNet.Repositories;

public interface IGamerRepository
{
    public Gamer Create(Gamer gamer);
    public List<Gamer> GetGamers();
    public Gamer GetGamer(string name);

}