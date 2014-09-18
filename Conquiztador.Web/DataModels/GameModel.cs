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
                    RedPlayerName = g.RedPlayer.UserName,
                    GreenPlayerName = g.GreenPlayer.UserName,
                    Map = g.Map,
                    State = g.State.ToString()
                };
            }
        }

        public Guid Id { get; set; }

        public string RedPlayerName { get; set; }

        public string GreenPlayerName { get; set; }

        public string Map { get; set; }

        public string State { get; set; }
    }
}