namespace Conquiztador.Web.Controllers
{
    using GameDb.Entities.Repositories;
    using GameDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    public class PlayersController : ApiController
    {
        private readonly IGameData data;

        public PlayersController()
            : this(new GameData())
        {
        }

        public PlayersController(IGameData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult HighScore()
        {
            var topUsers = this.data.Users.All().OrderBy(u => u.BestScore).Take(10);

            return Ok(topUsers);
        }
    }
}