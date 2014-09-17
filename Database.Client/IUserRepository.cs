﻿namespace Database.Client
{
    using System.Linq;

    public interface IUserRepository : IRepository
    {
        IQueryable All{ get; }

        void Insert(string name);

        bool Delete(string name);

        void Save();
    }
}