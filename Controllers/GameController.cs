using Microsoft.AspNetCore.Mvc;
using Task3.Models;
using Task3.Services;

namespace Task3.Controllers;

[ApiController]
[Route("api/[controller]")]

public class GameController : ControllerBase
{
    private readonly IGameService _gameService;
    private readonly IUserService _userService;
    private readonly ICalculateService _calculateService;

    public GameController(IGameService gameService,
    IUserService userService,
    ICalculateService calculateService)
    {
        _gameService = gameService;
        _userService = userService;
        _calculateService = calculateService;
    }

   [HttpPost("User")]
   public IActionResult CreateUser(CreateUser createUser)
   {
     var user = _userService.GetUser(createUser.Name!);

     if(user is null)
      {
        var newUser = new User
        {
         Name = createUser.Name,
         Step = 0,
        };

        _userService.CreateUser(newUser);

        var existUser = _userService.GetUser(createUser.Name!);
        
        var newGame = new GameModel
        {
          UserId = existUser.Id,
          RandomNumber = _calculateService.CreateNumber()
        };

        _gameService.CreateGame(newGame);

        return Ok(newGame.UserId);
      }
      
     var newGame1 = new GameModel
     {
       UserId = user.Id,
       RandomNumber = _calculateService.CreateNumber()
     };
     _gameService.CreateGame(newGame1);

     return Ok(newGame1.UserId);

   }

   [HttpPost("Play")]
   public IActionResult PlayGame(RequestModel model)
   {
       var existGame = _gameService.GetGame(model.UserId);

       int M = _calculateService.ValidateDigits(existGame.RandomNumber, model.insertNumber!)[0];
       int P = _calculateService.ValidateDigits(existGame.RandomNumber, model.insertNumber!)[1];
       string pandM =$" M:{M}  P:{P}";

       var newGame = new GameModel
       {
        UserId = model.UserId,
        GuessNumber = model.insertNumber,
        RandomNumber = existGame.RandomNumber,
        PandM = pandM
       };

       _gameService.CreateGame(newGame);

       var validated = _calculateService.ValidateDigits(existGame.RandomNumber, model.insertNumber!);
       
       if(validated[1] == 4)
       return Ok(true);

       if(_gameService.GetUserStep(existGame.UserId, existGame.RandomNumber) == 10)

       return Ok(false);
       var all = _gameService.GetAll(existGame.UserId, existGame.RandomNumber);
      
       return Ok(all.Skip(1));
   }

}