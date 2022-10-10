using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Topelab.Core.Resolver.Interfaces;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Adapters.Context
{
    /// <summary>
    /// Context factory for RegisterActivity
    /// </summary>
    public class RegisterActivityDbContextFactory : IRegisterActivityDbContextFactory
    {
        private readonly IRegisterActivityDbContextOptionsFactory optionsFactory;
        private readonly ILogger logger;
        private readonly IResolver resolver;
        private readonly Dictionary<string, IRegisterActivityDbContext> dbContexts;
        private readonly List<EventHandler<SavingChangesEventArgs>> whenSavingChanges = new List<EventHandler<SavingChangesEventArgs>>();
        private readonly List<EventHandler<SavedChangesEventArgs>> whenSavedChanges = new List<EventHandler<SavedChangesEventArgs>>();
        private string defaultConnectionStringKey;
        private bool areEventsEnabled;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="optionsFactory">Context Options factory</param>
        /// <param name="logger">Logger</param>
        /// <param name="resolver">Resolver for DI</param>
        public RegisterActivityDbContextFactory(IRegisterActivityDbContextOptionsFactory optionsFactory, ILogger logger, IResolver resolver)
        {
            this.optionsFactory = optionsFactory ?? throw new ArgumentNullException(nameof(optionsFactory));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.resolver = resolver ?? throw new ArgumentNullException(nameof(resolver));
            dbContexts = new Dictionary<string, IRegisterActivityDbContext>();
            defaultConnectionStringKey = "localserver";
            areEventsEnabled = false;
        }

        /// <summary>
        /// Establish default connection string key for this instance
        /// </summary>
        /// <param name="defaultConnectionStringKey">Default connection string key</param>
        public void SetDefaultConnectionStringKey(string defaultConnectionStringKey)
        {
            this.defaultConnectionStringKey = defaultConnectionStringKey;
        }

        /// <summary>
        /// Create RegisterActivityDbContext from connection string key existing at appsettings.json file
        /// </summary>
        /// <param name="connectionStringKey">Existing connection string key</param>
        /// <remarks>A new instance will be created always</remarks>
        public IRegisterActivityDbContext Create(string connectionStringKey = null)
        {
            var connString = ConfigHelper.GetConnectionString(connectionStringKey ?? defaultConnectionStringKey);
            return CreateFromConnectionString(connString);
        }

        /// <summary>
        /// Gets RegisterActivityDbContext from connection string key existing at appsettings.json file.
        /// Creates context if key was not created previously
        /// </summary>
        /// <param name="connectionStringKey">Existing connection string key</param>
        /// <remarks>Same <paramref name="connectionStringKey"/> will return same context if not disposed. If it has been disposed, new instance will be created</remarks>
        public IRegisterActivityDbContext Get(string connectionStringKey = null)
        {
            var connString = ConfigHelper.GetConnectionString(connectionStringKey ?? defaultConnectionStringKey);
            return GetFromConnectionString(connString);
        }

        /// <summary>
        /// Creates RegisterActivityDbContext with the specified connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        /// <remarks>A new instance will be created always</remarks>
        public IRegisterActivityDbContext CreateFromConnectionString(string connString)
        {
            var options = optionsFactory.Create(connString);
            IRegisterActivityDbContext dbContext = Create(options);
            return dbContext;
        }

        /// <summary>
        /// Gets RegisterActivityDbContext with the specified connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        /// <remarks>Same <paramref name="connString"/> will return same context if not disposed. If it has been disposed, new instance will be created</remarks>
        public IRegisterActivityDbContext GetFromConnectionString(string connString)
        {
            if (!dbContexts.TryGetValue(connString, out var dbContext))
            {
                dbContext = GetDbContextAndPutInCache(connString);
            }
            else
            {
                if (dbContext.Id == 0)
                {
                    dbContext = GetDbContextAndPutInCache(connString);
                }
            }

            return dbContext;
        }

        /// <summary>
        /// Create new RegisterActivityDbContext from context options
        /// </summary>
        /// <param name="options">Context options</param>
        /// <remarks>Always gets new instance</remarks>
        public IRegisterActivityDbContext Create(DbContextOptions<RegisterActivityDbContext> options)
        {
            var dbContext = resolver.Get<IRegisterActivityDbContext, DbContextOptions<RegisterActivityDbContext>, ILogger>(options, logger);
            if (areEventsEnabled)
            {
                dbContext.WhenSavingChanges(whenSavingChanges.ToArray());
                dbContext.WhenSavedChanges(whenSavedChanges.ToArray());
            }
            return dbContext;
        }

        /// <summary>
        /// Set event actions when saving changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        public void WhenSavingChanges(params EventHandler<SavingChangesEventArgs>[] actions)
        {
            whenSavingChanges.AddRange(actions);
        }

        /// <summary>
        /// Set event actions when saved changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        public void WhenSavedChanges(params EventHandler<SavedChangesEventArgs>[] actions)
        {
            whenSavedChanges.AddRange(actions);
        }

        /// <summary>
        /// Enable all events for next created db context and, optionally, the db context passed
        /// </summary>
        /// <param name="dbContext">Optional target db context: if is null, next db context created will have events enabled, otherwise, events are enabled on this and the next db context created</param>
        public void EnableEvents(IRegisterActivityDbContext dbContext = null)
        {
            if (!areEventsEnabled && dbContext != null)
            {
                dbContext.WhenSavingChanges(whenSavingChanges.ToArray());
                dbContext.WhenSavedChanges(whenSavedChanges.ToArray());
            }
            areEventsEnabled = true;
        }

        /// <summary>
        /// Disable all events on next creations
        /// </summary>
        public void DisableEventsOnNextCreations() => areEventsEnabled = false;

        private IRegisterActivityDbContext GetDbContextAndPutInCache(string connString)
        {
            TryDisposePreviousContext(connString);
            dbContexts[connString] = CreateFromConnectionString(connString);
            return dbContexts[connString];
        }

        private void TryDisposePreviousContext(string connString)
        {
            if (dbContexts.TryGetValue(connString, out var dbContext) && dbContext.Id > 0)
            {
                dbContext.Dispose();
            }
        }
    }
}
