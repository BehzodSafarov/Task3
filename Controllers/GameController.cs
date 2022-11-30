using DotNet.Models;
using DotNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace DotNet.Controllers;
[ApiController]
[Route("api/[controller]")]

public class GameController : ControllerBase
{
   static List<Send> list = new List<Send>();
   static string randomNumber = string.Empty;
   static int Step = 0;
   static bool Request = false;

    private readonly IGamerService _gamerService;
    private readonly IGameService _gameService;
   
    public GameController(
    IGameService gameService,
    IGamerService gamerService )
    {
        _gamerService = gamerService;
        _gameService = gameService;
    }

    [HttpPost("CreateGamer")]
    public IActionResult CreateGamer(string name)
    {
       Request = true;

       var gamer = _gamerService.GetGamer(name);

       if(!string.IsNullOrEmpty(gamer.Name))
       {
         var newGamer1 = new Gamer()
         {
           Name = gamer.Name,
           Games = null,
           Id = gamer.Id
         };
         return Ok(newGamer1);
       }

       var newGamer = new Gamer()
       {
         Name = name
       };
       var createdGamer = _gamerService.CreateGamer(newGamer);
       
       return Ok(createdGamer);
       
    }

    [HttpPost("Play")]
    public IActionResult PlayGame(string guessNumber, string UserId)
    {
       
       var userId = int.Parse(UserId);
       if(Request)
       {
        Step = 0;
        list.RemoveRange(0, list.Count());
        Request = false;
       }

      if(string.IsNullOrEmpty(randomNumber) || Step ==0 )
      {
         randomNumber = _gameService.CreateRandomNumber();
      } 
      
      var validated = _gameService.ValidateGuessNumber(randomNumber, guessNumber);
       
       var allGamesCaunt = _gameService.GetAllGames().Count();
       Step ++ ;
       var newAttempt = new Attempt()
       {
         M = validated[0],
         P = validated[1],
         GameId = allGamesCaunt,
       };

       var send = new Send()
       {
         M = validated[0],
         P = validated[1],
         GameId = allGamesCaunt
       };

      _gameService.CreateAttempt(newAttempt);
         
      list.Add(send);



      if(Step == 8)
      {
        var  newGame = new Game()
        {
          Step = Step,
          RandomNumber = randomNumber,
          GamerId = userId
        };

      Step = 0;
      var createGame = _gameService.CreateGame(newGame);
      var getGame = _gameService.GetGame(createGame.Id-1);
      var attempts = getGame.Attempts!.Select(x => ToList(x)).ToList();
      
      Request = false;
      list.RemoveRange(0,8);
      return Ok(attempts);
      }

      if(validated[1] == 4)
      {
        var  newGame = new Game()
       {
          Step = Step,
          RandomNumber = randomNumber,
          GamerId = userId
       };

       var createGame = _gameService.CreateGame(newGame);
       var getGame = _gameService.GetGame(createGame.Id-1);
       var attempts = getGame.Attempts!.Select(x => ToList(x)).ToList();

       Request = true;
       Step = 0;
       list.RemoveRange(0,list.Count());
       return Ok(attempts);

      }

      System.Console.WriteLine(randomNumber);

      return Ok(list);
    }
    

    [HttpGet("GetLider")]
    public IActionResult GetLider()
    {
      var games = _gameService.GetAllGames().Where(x => x.Step !=8);
      
      List<Winner> winners = new List<Winner>();

     foreach (var item in games)
     {
       var winner = new Winner()
       {
          Name = item.Gamer?.Name,
          WinStep = item.Step
       };
       winners.Add(winner);
     }
   
     for (int i = 0; i < winners.Count(); i++)
     {
       for (int j = 0; j < winners.Count(); j++)
       {
          var winner = new Winner();
          if(winners[i].WinStep < winners[j].WinStep)
          {
            winner = winners[j];
            winners[j] = winners[i];
            winners[i] = winner;
          }
       }
     }
      
      return Ok(winners);
    }
     

    private Attempt ToList(Attempt x)
    =>
    new Attempt()
    {
        Id = x.Id,
        M = x.M,
        P = x.P,
        GameId = x.GameId
    };
}

