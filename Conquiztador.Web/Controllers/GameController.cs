namespace Conquiztador.Web.Controllers
{
    using GameDb.Entities.Repositories;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using System.Text;
    using System.Web.Http;

    using Antlr.Runtime.Tree;

    //  using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;
    using GameDb.Models;
    using System;
    using Conquiztador.Web.DataModels;

    [Authorize]
    public class GameController : ApiController
    {
        //private readonly IGameData data;
        //private readonly Random generator;

        //public GameController()
        //    : this(new GameData())
        //{
        //}

        //public GameController(IGameData data)
        //{
        //    this.data = data;
        //    this.generator = new Random();
        //}

        //[HttpPost]
        //public IHttpActionResult Create()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var game = new Game { RedPlayerId = userId };
        //    this.data.Games.Add(game);
        //    this.data.SaveChanges();

        //    var gameDataModel =
        //        this.data.Games.All()
        //            .Where(x => x.Id == game.Id)
        //            .Select(GameModel.FromGame)
        //            .FirstOrDefault();

        //    return Ok(gameDataModel);
        //}

        //[HttpPost]
        //public IHttpActionResult Join()
        //{
        //    var userId = User.Identity.GetUserId();

        //    var firstAvailableGame =
        //        this.data.Games.All()
        //            .FirstOrDefault(x => x.State == GameState.WaitingForSecondPlayer && x.RedPlayerId != userId);

        //    if (firstAvailableGame == null)
        //    {
        //        return this.NotFound();
        //    }

        //    firstAvailableGame.GreenPlayerId = userId;
        //    firstAvailableGame.State = GameState.OpenQuestion;
        //    this.data.SaveChanges();

        //    var gameDataModel =
        //        this.data.Games.All()
        //            .Where(x => x.Id == firstAvailableGame.Id)
        //            .Select(GameModel.FromGame)
        //            .FirstOrDefault();

        //    return this.Ok(gameDataModel);
        //}

        //[HttpGet]
        //public IHttpActionResult Status([Required]string gameId)
        //{
        //    var userId = User.Identity.GetUserId();

        //    if (!ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var gameIdAsGuid = new Guid(gameId);
        //    var gameDataModel =
        //        this.data.Games.All()
        //            .Where(x => x.Id == gameIdAsGuid && (x.RedPlayerId == userId || x.GreenPlayerId == userId))
        //            .Select(GameModel.FromGame)
        //            .FirstOrDefault();

        //    if (gameDataModel == null)
        //    {
        //        return this.NotFound();
        //    }

        //    return this.Ok(gameDataModel);
        //}

        //[HttpGet]
        //public IHttpActionResult GetQuestion([Required]string gameId)
        //{
        //    var gameIdAsGuid = new Guid(gameId);
        //    var currentGame =
        //        this.data.Games
        //            .All()
        //            .Where(g => g.Id  == gameIdAsGuid)
        //            .FirstOrDefault();

        //    if (currentGame == null)
        //    {
        //        return this.NotFound();
        //    }

        //    if (currentGame.State != GameState.NotAnswered)
        //    {
        //        currentGame.State = GameState.NotAnswered;
        //    }

        //    this.data.SaveChanges();

        //    var openQuestionsIds = this.data.OpenQuestions.All().Select(o => o.Id).ToArray();
        //    var closedQuestionsIds = this.data.ClosedQuestions.All().Select(c => c.Id).ToArray();


        //    var questionType = generator.Next(0, 2);

        //    if (questionType == 0)
        //    {
        //        if (openQuestionsIds.Length == 0)
        //        {
        //            return NotFound();
        //        }

        //        var id = this.generator.Next(0, openQuestionsIds.Length);
        //        var question = this.data.OpenQuestions.GetById(id);

        //        return Ok(new
        //        {
        //            Type = "open",
        //            Question = question.Question
        //        });
        //    }
        //    else
        //    {
        //        if (closedQuestionsIds.Length == 0)
        //        {
        //            return NotFound();
        //        }

        //        var id = this.generator.Next(0, closedQuestionsIds.Length);
        //        var question = this.data.ClosedQuestions.GetById(id);

        //        return Ok(new
        //        {
        //            Type = "closed",
        //            Question = question.Question,
        //            AnswerA = question.AnswerA,
        //            AnswerB = question.AnswerB,
        //            AnswerC = question.AnswerC,
        //            AnswerD = question.AnswerD
        //        });
        //    }
        //}

        //[HttpPost]
        //public IHttpActionResult Answer(PlayRequestDataModel request)
        //{
        //    var userId = User.Identity.GetUserId();

        //    if (!ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var gameIdAsGuid = new Guid(request.GameId);
        //    var game =
        //        this.data.Games.All()
        //            .FirstOrDefault(
        //                x => x.Id == gameIdAsGuid && (x.RedPlayerId == userId || x.GreenPlayerId == userId));

        //    if (game == null)
        //    {
        //        return this.NotFound();
        //    }


        //    if (game.State == GameState.NotAnswered)
        //    {
        //        //update field
        //        // get red or green

        //        game.State = GameState.RedAnswered;
        //    }
        //    else
        //    {
        //        return Ok(new
        //        {
        //            CorrectAnswer =
        //            Message = "You are slow!"
                    
        //        });

        //    }



        //}

        //[HttpPost]
        //public IHttpActionResult Play([FromUri]PlayRequestDataModel request)
        //{
        //    // igrata
        //    // question
        //    // returva dali e poznal

        //    var userId = User.Identity.GetUserId();

        //    if (!ModelState.IsValid)
        //    {
        //        return this.BadRequest(this.ModelState);
        //    }

        //    var gameIdAsGuid = new Guid(request.GameId);
        //    var game =
        //        this.data.Games.All()
        //            .FirstOrDefault(
        //                x => x.Id == gameIdAsGuid && (x.RedPlayerId == userId || x.GreenPlayerId == userId));

        //    if (game == null)
        //    {
        //        return this.NotFound();
        //    }

        //    if (game.State != GameState.RedChoose && game.State != GameState.GreenChoose)
        //    {
        //        return this.BadRequest(string.Format("Invalid game state: {0}", game.State));
        //    }

        //    if ((game.State == GameState.RedChoose && game.RedPlayerId != userId)
        //        || (game.State == GameState.GreenChoose && game.GreenPlayerId != userId))
        //    {
        //        return this.BadRequest(string.Format("It's not your turn!"));
        //    }

        //    int positionIndex = ((request.Row - 1) * 3) + request.Col - 1;
        //    if (game.Map[positionIndex] != '-')
        //    {
        //        return this.BadRequest("This position is already taken. Please choose a different one.");
        //    }

        //    var board = new StringBuilder(game.Board);
        //    board[positionIndex] = game.State == GameState.TurnX ? 'X' : 'O';
        //    var boardAsString = board.ToString();
        //    game.Board = boardAsString;
        //    game.State = game.State == GameState.TurnX ? GameState.TurnO : GameState.TurnX;

        //    var gameResult = this.CheckGameResult(game.Board);
        //    switch (gameResult)
        //    {
        //        case GameResult.XWins:
        //            game.State = GameState.GameWonByX;
        //            break;
        //        case GameResult.OWins:
        //            game.State = GameState.GameWonByO;
        //            break;
        //        case GameResult.Draw:
        //            game.State = GameState.GameDraw;
        //            break;
        //    }

        //    this.data.SaveChanges();

        //    var gameDataModel =
        //        this.data.Games.All()
        //            .Where(x => x.Id == gameIdAsGuid && (x.FirstPlayerId == userId || x.SecondPlayerId == userId))
        //            .Project()
        //            .To<GameInfoDataModel>()
        //            .FirstOrDefault();

        //    return this.Ok(gameDataModel);
        //}

        //private GameResult CheckGameResult(string boardAsString)
        //{
        //    var board = new char[3, 3];
        //    for (int i = 0; i < boardAsString.Length; i++)
        //    {
        //        int row = i / 3;
        //        int col = i % 3;
        //        board[row, col] = boardAsString[i];
        //    }

        //    //// TODO: Implement Check if the game is won by X or O player

        //    if (!boardAsString.Contains('-'))
        //    {
        //        return GameResult.Draw;
        //    }
        //    else
        //    {
        //        return GameResult.NotFinished;
        //    }
        //}
    }
}