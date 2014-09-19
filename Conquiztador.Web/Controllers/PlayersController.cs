namespace Conquiztador.Web.Controllers
{
    using GameDb.Entities.Repositories;
    using GameDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Antlr.Runtime.Tree;

    //  using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;
    using GameDb.Models;
    using System;
    using Conquiztador.Web.DataModels;

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
            var topUsers = this.data.Users.All()
                .Select(UserModel.FromUser)
                .OrderBy(u => u.BestScore)
                .Take(10)
                .ToArray();

            return Ok(topUsers);
        }

        [Authorize]
        [HttpPut]
        public IHttpActionResult Update(int score)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.Identity.GetUserId();

            var user = this.data.Users.All()
                 .Where(u => u.Id == userId)
                 .Select(UserModel.FromUser)
                 .FirstOrDefault();

            if (user == null)
            {
                return BadRequest("Such user does not exists!");
            }

            if (user.BestScore == null)
            {
                user.BestScore = 0;
                user.Games = 0;
                this.data.SaveChanges();
            }

            user.Games++;
            this.data.SaveChanges();

            if (user.BestScore < score)
            {
                user.BestScore = score;
                this.data.SaveChanges();
            }

            return Ok(user);
        }
    }
}