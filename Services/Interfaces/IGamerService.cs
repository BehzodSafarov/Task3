using DotNet.Models;

namespace DotNet.Services;


public interface IGamerService
{
    public Gamer CreateGamer(Gamer gamer);
    public Gamer GetGamer(string  name);
    public List<Gamer> GetGamers();

}