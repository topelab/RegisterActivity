using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Builders;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Adapters.Context
{
    /// <summary>
    /// Context for module RegisterActivity
    /// </summary>
    public partial class RegisterActivityDbContext : DbContext, IRegisterActivityDbContext
    {
        private readonly ILogger logger;
        private readonly string connectionString;
        private static int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        /// <param name="logger">Logger</param>
        public RegisterActivityDbContext(ILogger logger = null)
        {
            Id = ++id;
            this.logger = logger;
            connectionString = Environment.ExpandEnvironmentVariables(ConfigHelper.GetConnectionString());
            OpenIfMemoryDb();
            this.logger?.LogInformation($"Starting instance number {Id} from RegisterActivityDbContext");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="logger">Logger</param>
        public RegisterActivityDbContext(DbContextOptions<RegisterActivityDbContext> options, ILogger logger = null) : base(options)
        {
            Id = ++id;
            this.logger = logger;
            connectionString = options.Extensions.OfType<RelationalOptionsExtension>().FirstOrDefault()?.ConnectionString;
            OpenIfMemoryDb();
            this.logger?.LogInformation($"Starting instance number {Id} from RegisterActivityDbContext (with options)");
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
            if (connectionString.Contains(":memory:"))
            {
                Database.OpenConnection();
            }
        }
    }
}
