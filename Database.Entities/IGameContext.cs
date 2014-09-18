namespace GameDb.Entities
{
    using GameDb.Models;
    using System;
    using System.Data.Entity;

    public interface IGameContext
    {
        IDbSet<ClosedQuestion> ClosedQuestions { get; set; }

        IDbSet<OpenQuestion> OpenQuestions { get; set; }

        IDbSet<Game> Games { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}
