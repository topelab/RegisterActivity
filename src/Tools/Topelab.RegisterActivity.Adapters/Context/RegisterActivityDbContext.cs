using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Topelab.RegisterActivity.Domain.Entities;
using Topelab.RegisterActivity.Adapters.Builders;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Topelab.RegisterActivity.Adapters.Context
{
    /// <summary>
    /// Context for module RegisterActivity
    /// </summary>
    /// <seealso cref="DbContext" />
    /// <seealso cref="IRegisterActivityDbContext" />
    public partial class RegisterActivityDbContext : DbContext, IRegisterActivityDbContext
    {
        private static ILoggerFactory loggerFactory;
        private static ILogger logger;
        private static int id;
        private string connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        public RegisterActivityDbContext()
        {
            Id = ++id;
            PrepareHandlers();
            OpenIfMemoryDb();
            logger?.LogInformation($"Starting instance number {Id} from RegisterActivityDbContext");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public RegisterActivityDbContext(DbContextOptions<RegisterActivityDbContext> options) : base(options)
        {
            Id = ++id;
            PrepareHandlers();
            connectionString = options.Extensions.OfType<RelationalOptionsExtension>().FirstOrDefault()?.ConnectionString;
            OpenIfMemoryDb();
            logger?.LogInformation($"Starting instance number {Id} from RegisterActivityDbContext (with options)");
        }

        /// <summary>
        /// Sets the logger factory
        /// </summary>
        public static void SetLoggerFactory(ILoggerFactory loggerFactory)
        {
            // loggerFactory could be null, it's ok
            RegisterActivityDbContext.loggerFactory = loggerFactory;
            logger = loggerFactory?.CreateLogger<RegisterActivityDbContext>();
            logger?.LogInformation("Starting Loggin at RegisterActivityDbContext");
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>DbSet for Winlog</summary>
        public virtual DbSet<Winlog> Winlog { get; set; }

        /// <summary>
        /// Discards the changes.
        /// </summary>
        public void DiscardChanges()
        {
            ChangeTracker.Entries()
                .Where(e => e.Entity != null).ToList()
                .ForEach(e => e.State = EntityState.Detached);
        }

        /// <summary>
        /// <para>
        /// Override this method to configure the database (and other options) to be used for this context.
        /// This method is called for each instance of the context that is created.
        /// The base implementation does nothing.
        /// </para>
        /// <para>
        /// In situations where an instance of <see cref="T:Microsoft.EntityFrameworkCore.DbContextOptions" /> may or may not have been passed
        /// to the constructor, you can use <see cref="P:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.IsConfigured" /> to determine if
        /// the options have already been set, and skip some or all of the logic in
        /// <see cref="M:Microsoft.EntityFrameworkCore.DbContext.OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder)" />.
        /// </para>
        /// </summary>
        /// <param name="optionsBuilder">A builder used to create or modify options for this context. Databases (and other extensions)
        /// typically define extension methods on this object that allow you to configure the context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                if (loggerFactory != null)
                {
                    optionsBuilder.UseLoggerFactory(loggerFactory);
                }

                connectionString ??= Environment.ExpandEnvironmentVariables(ConfigHelper.GetConnectionString());
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>
        /// If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.
        /// </remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            WinlogBuilder.Build(modelBuilder);

        }

        private void OpenIfMemoryDb()
        {
            connectionString ??= Environment.ExpandEnvironmentVariables(ConfigHelper.GetConnectionString());
            if (connectionString.Contains(":memory:"))
            {
                Database.OpenConnection();
            }
        }

        private void PrepareHandlers()
        {
            SavingChanges += (s, e) => logger?.LogInformation("Running Before Save Changes");
            SavedChanges += (s, e) => logger?.LogInformation("Running After Save Changes");
            SaveChangesFailed += (s, e) => logger?.LogError("Error Saving Changes: {Message}", e.Exception.Message);
        }
    }
}
