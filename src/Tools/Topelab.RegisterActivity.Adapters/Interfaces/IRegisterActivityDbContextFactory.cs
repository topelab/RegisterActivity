using Microsoft.EntityFrameworkCore;
using System;
using Topelab.RegisterActivity.Adapters.Context;

namespace Topelab.RegisterActivity.Adapters.Interfaces
{
    /// <summary>
	/// Define implementation for IRegisterActivityDbContext factory
	/// </summary>
    public interface IRegisterActivityDbContextFactory
    {
        /// <summary>
        /// Create RegisterActivityDbContext from connection string key existing at appsettings.json file
        /// </summary>
        /// <param name="connectionStringKey">Existing connection string key</param>
        /// <remarks>A new instance will be created always</remarks>
        IRegisterActivityDbContext Create(string connectionStringKey = null);

        /// <summary>
        /// Gets RegisterActivityDbContext from connection string key existing at appsettings.json file.
        /// Creates context if key was not created previously
        /// </summary>
        /// <param name="connectionStringKey">Existing connection string key</param>
        /// <remarks>Same <paramref name="connectionStringKey"/> will return same context if not disposed. If it has been disposed, new instance will be created</remarks>
        IRegisterActivityDbContext Get(string connectionStringKey = null);

        /// <summary>
        /// Create new RegisterActivityDbContext from context options
        /// </summary>
        /// <param name="options">Context options</param>
        /// <remarks>Always gets new instance</remarks>
        IRegisterActivityDbContext Create(DbContextOptions<RegisterActivityDbContext> options);

        /// <summary>
        /// Creates RegisterActivityDbContext with the specified connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        /// <remarks>A new instance will be created always</remarks>
        IRegisterActivityDbContext CreateFromConnectionString(string connString);

        /// <summary>
        /// Gets RegisterActivityDbContext with the specified connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        /// <remarks>Same <paramref name="connString"/> will return same context if not disposed. If it has been disposed, new instance will be created</remarks>
        IRegisterActivityDbContext GetFromConnectionString(string connString);

        /// <summary>
        /// Establish default connection string key for this instance
        /// </summary>
        /// <param name="defaultConnectionStringKey">Default connection string key</param>
        void SetDefaultConnectionStringKey(string defaultConnectionStringKey);

        /// <summary>
        /// Set event actions when saving changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        void WhenSavingChanges(params EventHandler<SavingChangesEventArgs>[] actions);

        /// <summary>
        /// Set event actions when saved changes on db context
        /// </summary>
        /// <param name="actions">One or more even actions</param>
        void WhenSavedChanges(params EventHandler<SavedChangesEventArgs>[] actions);

        /// <summary>
        /// Enable all events for next created db context and, optionally, the db context passed
        /// </summary>
        /// <param name="dbContext">Optional target db context: if is null, next db context created will have events enabled, otherwise, events are enabled on this and the next db context created</param>
        void EnableEvents(IRegisterActivityDbContext dbContext = null);

        /// <summary>
        /// Disable all events on next creations
        /// </summary>
        void DisableEventsOnNextCreations();
    }
}