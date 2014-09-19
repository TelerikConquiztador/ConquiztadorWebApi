using GameDb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Conquiztador.Web.DataModels
{
    public class UserModel
    {
        public static Expression<Func<User, UserModel>> FromUser
        {
            get
            {
                return u => new UserModel
                {
                    Id = u.Id,
                    Username = u.UserName,
                    BestScore = u.BestScore,
                    Games = u.Games
                };
            }
        }

        public string Id { get; set; }

        public string Username { get; set; }
        
        public int? BestScore { get; set; }

        public int? Games { get; set; }
    }
}