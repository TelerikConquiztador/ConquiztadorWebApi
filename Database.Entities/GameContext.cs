namespace GameDb.Entities
{
    using GameDb.Entities.Migrations;
    using GameDb.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;

    public class GameContext : IdentityDbContext<User>, IGameContext
    {
        public GameContext()
            : base("GameContext", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<GameContext, Configuration>());
        }

        public static GameContext Create()
        {
            return new GameContext();
        }

        public IDbSet<ClosedQuestion> ClosedQuestions { get; set; }

        public IDbSet<OpenQuestion> OpenQuestions { get; set; }

        public IDbSet<Game> Games { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        public void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
