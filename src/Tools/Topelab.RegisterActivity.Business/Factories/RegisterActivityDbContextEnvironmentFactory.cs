using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Business.Factories
{
    /// <summary>
    /// Db Context Options factory for RegisterActivity
    /// </summary>
    public class RegisterActivityDbContextEnvironmentFactory : IRegisterActivityDbContextOptionsFactory
    {
        private Dictionary<string, DbContextOptions<RegisterActivityDbContext>> optionsCache;

        /// <summary>
        /// Constructor
        /// </summary>
        public RegisterActivityDbContextEnvironmentFactory()
        {
            optionsCache = new Dictionary<string, DbContextOptions<RegisterActivityDbContext>>();
        }

        /// <summary>
        /// Create options for RegisterActivityDbContext from connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        public DbContextOptions<RegisterActivityDbContext> Create(string connString)
        {
            connString = Environment.ExpandEnvironmentVariables(connString);
            if (!optionsCache.TryGetValue(connString, out var dbContextOptions))
            {
                SqliteConnection.ClearAllPools();
                dbContextOptions = new DbContextOptionsBuilder<RegisterActivityDbContext>()
                    .UseSqlite(connString)
                    .Options;
                optionsCache.Add(connString, dbContextOptions);
            }
            return dbContextOptions;
        }

    }
}
