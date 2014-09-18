namespace Conquiztador.Web.DataModels
{
    using GameDb.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Linq;

    public class GameModel
    {
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return g => new GameModel
                {
                    Id = g.Id,
                    PlayerName = g.Player.UserName,
                    Map = g.Map
                };
            }
        }

        public Guid Id { get; set; }

        public string PlayerName { get; set; }

        public string Map { get; set; }
    }
}