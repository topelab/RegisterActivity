using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Topelab.RegisterActivity.Adapters.Builders;
using Topelab.RegisterActivity.Adapters.Extensions;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;
using Topelab.RegisterActivity.Domain.Interfaces;

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

        private readonly List<EventHandler<SavingChangesEventArgs>> whenSavingChanges = new();
        private readonly List<EventHandler<SavedChangesEventArgs>> whenSavedChanges = new();
        private readonly Queue<Action> actionsQueue = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        /// <param name="logger">Logger</param>
        public RegisterActivityDbContext(ILogger logger = null)
        {
            this.logger = logger;
            connectionString = Environment.ExpandEnvironmentVariables(ConfigHelper.GetConnectionString());
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterActivityDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        /// <param name="logger">Logger</param>
        public RegisterActivityDbContext(DbContextOptions<RegisterActivityDbContext> options, ILogger logger = null) : base(options)
        {
            this.logger = logger;
            connectionString = options.Extensions.OfType<RelationalOptionsExtension>().FirstOrDefault()?.ConnectionString;
            Initialize("(with options)");
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// Actions queue
        /// </summary>
        public Queue<Action> Actions => actionsQueue;

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
        /// Set event actions when saving changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        public void WhenSavingChanges(params EventHandler<SavingChangesEventArgs>[] actions)
        {
            whenSavingChanges.AddRange(actions);
            foreach (var action in actions)
            {
                SavingChanges += action;
            }
        }

        /// <summary>
        /// Set event actions when saved changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        public void WhenSavedChanges(params EventHandler<SavedChangesEventArgs>[] actions)
        {
            whenSavedChanges.AddRange(actions);
            foreach (var action in actions)
            {
                SavedChanges += action;
            }
        }

        /// <summary>
        /// Add an action to actions queue
        /// </summary>
        /// <param name="action">Action</param>
        public void AddAction(Action action)
        {
            actionsQueue.Enqueue(action);
        }

        /// <summary>
        /// Clear all added actions
        /// </summary>
        public void ClearActions()
        {
            actionsQueue.Clear();
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

        /// <inheritdoc/>
        public override void Dispose()
        {
            logger?.LogInformation($"Disposing instance number {Id} from {nameof(RegisterActivityDbContext)}");
            Id = 0;

            DisableEvents();
            whenSavingChanges.Clear();
            whenSavedChanges.Clear();
            SavingChanges -= OnRegisterActivityDbContextSavingChanges;

            base.Dispose();
        }

        /// <inheritdoc/>
        public void EnableEvents()
        {
            DisableEvents();
            foreach (var item in whenSavingChanges)
            {
                SavingChanges += item;
            }
            foreach (var item in whenSavedChanges)
            {
                SavedChanges += item;
            }
        }

        /// <inheritdoc/>
        public void DisableEvents()
        {
            foreach (var item in whenSavingChanges)
            {
                SavingChanges -= item;
            }
            foreach (var item in whenSavedChanges)
            {
                SavedChanges -= item;
            }
        }

        private void Initialize(string logMessage = null)
        {
            Id = ++id;
            logMessage = logMessage == null ? string.Empty : $" {logMessage}";
            logger?.LogInformation($"Starting instance number {Id} from {nameof(RegisterActivityDbContext)}{logMessage}");
            SavingChanges += OnRegisterActivityDbContextSavingChanges;
        }

        private void OnRegisterActivityDbContextSavingChanges(object sender, SavingChangesEventArgs e)
        {
            var entries = ((IRegisterActivityDbContext)sender).ChangeTracker.Entries()
                .Where(e => e.Entity is IAuditableEntityCreationDate)
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                entry.UpdateDates();
            }
        }
    }
}
