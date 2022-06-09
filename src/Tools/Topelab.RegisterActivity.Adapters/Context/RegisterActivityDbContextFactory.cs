using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Adapters.Context
{
    /// <summary>
    /// Context factory for RegisterActivity
    /// </summary>
    public class RegisterActivityDbContextFactory : IRegisterActivityDbContextFactory
    {
        private readonly ILoggerFactory loggerFactory;
        private readonly ILogger logger;
        private readonly Dictionary<string, DbContextOptions<RegisterActivityDbContext>> dbContextOptions;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="loggerFactory">Logger factory</param>
        /// <param name="logger">Logger</param>
        public RegisterActivityDbContextFactory(ILoggerFactory loggerFactory, ILogger logger)
        {
            this.loggerFactory = loggerFactory ?? throw new System.ArgumentNullException(nameof(loggerFactory));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
            dbContextOptions = new Dictionary<string, DbContextOptions<RegisterActivityDbContext>>();
        }

        /// <summary>
        /// Create options for RegisterActivityDbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        public RegisterActivityDbContext Create(string connectionStringLabel = "localserver")
        {
            DbContextOptions<RegisterActivityDbContext> options;

            if (dbContextOptions.ContainsKey(connectionStringLabel))
            {
                options = dbContextOptions[connectionStringLabel];
            }
            else
            {
                var connString = ConfigHelper.GetConnectionString(connectionStringLabel);
                options = CreateDbOptionsFromConnectionString(connString);
                dbContextOptions.Add(connectionStringLabel, options);
            }

            return new RegisterActivityDbContext(options, logger);
        }

        /// <summary>
        /// Create options for RegisterActivityDbContext from connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        public RegisterActivityDbContext CreateFromConnectionString(string connString)
        {
            var options = CreateDbOptionsFromConnectionString(connString);
            return new RegisterActivityDbContext(options, logger);
        }

        private DbContextOptions<RegisterActivityDbContext> CreateDbOptionsFromConnectionString(string connString)
        {
            return new DbContextOptionsBuilder<RegisterActivityDbContext>()
                .UseLoggerFactory(loggerFactory)
                .UseSqlite(connString)
                .Options;
        }
    }
}
