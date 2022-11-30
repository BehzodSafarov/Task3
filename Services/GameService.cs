using DotNet.Models;
using DotNet.Repositories;

namespace DotNet.Services;

public class GameService : IGameService
{
    private readonly IGameRepository _repository;
    private readonly ILogger<GameService> _logger;

    public GameService(ILogger<GameService> logger, IGameRepository repository)
    {
       _repository = repository;
       _logger = logger;
    }

    public Attempt CreateAttempt(Attempt attempt)
    {
        try
        {
            var createdAttempt = _repository.CreateAttempt(attempt);

            return createdAttempt;
        }
        catch (System.Exception)
        {
            
            throw;
        }
    }

    public Game CreateGame(Game game)
    {
        try
        {
            var cretedGame = _repository.Create(game);
            
            _logger.LogInformation($"game is saved {game}");

            return cretedGame;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Game is not saved {game}");

            throw new Exception(e.Message);
        }
    }

    public string CreateRandomNumber()
    {
         var random = new Random();
            string number = "";

            for (int i = 0; i < 4; i++)
            {
              sameNumber :
              int a = random.Next(0,9);

              if(!number.Contains(a.ToString()))
              {
                number = number+a;
              }
              else goto sameNumber;
            }

            return number;
    }

    public List<Game> GetAllGames()
    {
       var games = _repository.AllGames();

       return games;
    }

    public Game GetGame(int id)
    {
        try
        {
            var game = _repository.GetGame(id);
            
            _logger.LogInformation($"Game is taked with {id}");

            return game;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Game is not taked with Id: {id}");

            throw new Exception(e.Message);
        }
    }

    public List<Game> GetGames(int userId)
    {
        try
        {
            var games = _repository.GetGames(userId);

            _logger.LogInformation($"Games  taked with UserId {userId}");

            return games;
        }
        catch (System.Exception e)
        {
            _logger.LogInformation($"Games not taked with UserId {userId}");

            throw new Exception(e.Message);
        }
    }

    public int[] ValidateGuessNumber(string number, string insertNumber)
    {
          int m = 0;
          int p = 0;

          var numberArray = ToArray(number);
          var insertNumberArray =  ToArray(insertNumber.ToString());

          for (int i = 0; i < 4; i++)
          {
            for (int j = 0; j < 4; j++)
            {
               if(numberArray[i] == insertNumberArray[j])
               {
                m++;
               } 
            }

             if(numberArray[i] == insertNumberArray[i])
               {
                p++;
               } 
          }

          int[] result = {m-p,p};
          return result;
    }
      private int[] ToArray(string number)
      {
          int[] array = new int[number.Length];

          for (int i = 0; i < number.Length; i++)
          {
              array[i] = int.Parse(number[i].ToString());
          }

          return array;
      }
}