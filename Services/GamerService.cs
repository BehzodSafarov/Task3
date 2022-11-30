using DotNet.Models;
using DotNet.Repositories;

namespace DotNet.Services;

public class GamerService : IGamerService
{
    private readonly IGamerRepository _repository;
    private readonly ILogger<GamerService> _logger;

    public GamerService(ILogger<GamerService> logger,IGamerRepository repository)
    {
        _repository = repository;
        _logger = logger;
    }
    public Gamer CreateGamer(Gamer gamer)
    {
        try
        {
            var createdGamer = _repository.Create(gamer);
            
            _logger.LogInformation($"Gamer created Sucssesefuly {gamer}");

            return createdGamer;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Gamer created not Sucssesefuly {gamer}");

            throw new Exception(e.Message);
        }
    }

    public Gamer GetGamer(string name)
    {
        try
        {
             var gamer = _repository.GetGamer(name)??null;
             
             
            _logger.LogInformation($"Gamer is taked with Name:{name}");
             
            return gamer ;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Gamer is not taked with Name:{name}");

            throw new Exception(e.Message);
        }
    }

    public List<Gamer> GetGamers()
    {
        try
        {
            var gamers = _repository.GetGamers()??null;

            _logger.LogInformation($"Gamers are taked ");

            return gamers;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Gamers are not taked ");

            throw new Exception(e.Message);
        }
    }
}