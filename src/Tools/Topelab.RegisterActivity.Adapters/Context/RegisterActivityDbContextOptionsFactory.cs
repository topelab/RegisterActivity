using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Adapters.Context
{
    /// <summary>
    /// Db Context Options factory for RegisterActivity
    /// </summary>
    public class RegisterActivityDbContextOptionsFactory : IRegisterActivityDbContextOptionsFactory
    {
        private readonly ILoggerFactory loggerFactory;
        private Dictionary<string, DbContextOptions<RegisterActivityDbContext>> optionsCache;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory">Logger factory</param>
        public RegisterActivityDbContextOptionsFactory(ILoggerFactory loggerFactory)
        {
            this.loggerFactory = loggerFactory ?? throw new ArgumentNullException(nameof(loggerFactory));
            optionsCache = new Dictionary<string, DbContextOptions<RegisterActivityDbContext>>();
        }

        /// <summary>
        /// Create options for RegisterActivityDbContext from connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        public DbContextOptions<RegisterActivityDbContext> Create(string connString)
        {
            if (!optionsCache.TryGetValue(connString, out DbContextOptions<RegisterActivityDbContext> dbContextOptions))
            {
                dbContextOptions = new DbContextOptionsBuilder<RegisterActivityDbContext>()
                    .UseLoggerFactory(loggerFactory)
                    .UseSqlite(connString)
                    .Options;
                optionsCache.Add(connString, dbContextOptions);
            }
            return dbContextOptions;
        }

    }
}
