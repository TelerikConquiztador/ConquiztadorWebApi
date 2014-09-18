﻿namespace GameDb.Entities.Repositories
{
    using GameDb.Models;

    public interface IGameData
    {
        IRepository<User> Users { get; }

        IRepository<OpenQuestion> OpenQuestions { get; }

        IRepository<ClosedQuestion> ClosedQuestions { get; }

        IRepository<Game> Games { get; }

        void SaveChanges();
    }
}
