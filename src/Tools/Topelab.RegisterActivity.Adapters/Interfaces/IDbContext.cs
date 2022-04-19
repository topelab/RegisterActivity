using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Topelab.RegisterActivity.Adapters.Interfaces
{
    /// <summary>
    /// Interface fro DbContext<br />
    /// <see cref="DbContext"/>
    /// </summary>
    public interface IDbContext : IDisposable, IAsyncDisposable, IInfrastructure<IServiceProvider>, IResettableService
    {
        /// <summary>
        /// Discards the changes.
        /// </summary>
        void DiscardChanges();

        /// <summary>
        /// Gets the context identifier.
        /// </summary>
        /// <value>
        /// The context identifier.
        /// </value>
        DbContextId ContextId { get; }
        /// <summary>
        /// Gets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        IModel Model { get; }
        /// <summary>
        /// Gets the change tracker.
        /// </summary>
        /// <value>
        /// The change tracker.
        /// </value>
        ChangeTracker ChangeTracker { get; }
        /// <summary>
        /// Gets the database.
        /// </summary>
        /// <value>
        /// The database.
        /// </value>
        DatabaseFacade Database { get; }

        /// <summary>
        /// An event fired at the beginning of a call to SaveChanges or SaveChangesAsync
        /// </summary>
        event EventHandler<SavingChangesEventArgs> SavingChanges;
        /// <summary>
        /// An event fired at the end of a call to SaveChanges or SaveChangesAsync
        /// </summary>
        event EventHandler<SavedChangesEventArgs> SavedChanges;
        /// <summary>
        /// An event fired if a call to SaveChanges or SaveChangesAsync fails with an exception.
        /// </summary>
        event EventHandler<SaveChangesFailedEventArgs> SaveChangesFailed;

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry Add([NotNull] object entity);
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<TEntity> Add<TEntity>([NotNull] TEntity entity) where TEntity : class;
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<EntityEntry> AddAsync([NotNull] object entity, CancellationToken cancellationToken = default);
        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>([NotNull] TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange([NotNull] IEnumerable<object> entities);
        /// <summary>
        /// Adds the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AddRange([NotNull] params object[] entities);
        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task AddRangeAsync([NotNull] IEnumerable<object> entities, CancellationToken cancellationToken = default);
        /// <summary>
        /// Adds the range asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns></returns>
        Task AddRangeAsync([NotNull] params object[] entities);
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<TEntity> Attach<TEntity>([NotNull] TEntity entity) where TEntity : class;
        /// <summary>
        /// Attaches the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry Attach([NotNull] object entity);
        /// <summary>
        /// Attaches the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AttachRange([NotNull] params object[] entities);
        /// <summary>
        /// Attaches the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void AttachRange([NotNull] IEnumerable<object> entities);
        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry Entry([NotNull] object entity);
        /// <summary>
        /// Entries the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<TEntity> Entry<TEntity>([NotNull] TEntity entity) where TEntity : class;
        /// <summary>
        /// Finds the specified key values.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        TEntity Find<TEntity>(params object[] keyValues) where TEntity : class;
        /// <summary>
        /// Finds the specified entity type.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        object Find([NotNull] Type entityType, params object[] keyValues);
        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<TEntity> FindAsync<TEntity>(object[] keyValues, CancellationToken cancellationToken) where TEntity : class;
        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        ValueTask<object> FindAsync([NotNull] Type entityType, object[] keyValues, CancellationToken cancellationToken);
        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        ValueTask<TEntity> FindAsync<TEntity>(params object[] keyValues) where TEntity : class;
        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="entityType">Type of the entity.</param>
        /// <param name="keyValues">The key values.</param>
        /// <returns></returns>
        ValueTask<object> FindAsync([NotNull] Type entityType, params object[] keyValues);
        /// <summary>
        /// Froms the expression.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="expression">The expression.</param>
        /// <returns></returns>
        IQueryable<TResult> FromExpression<TResult>([NotNull] Expression<Func<IQueryable<TResult>>> expression);
        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry Remove([NotNull] object entity);
        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<TEntity> Remove<TEntity>([NotNull] TEntity entity) where TEntity : class;
        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange([NotNull] params object[] entities);
        /// <summary>
        /// Removes the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void RemoveRange([NotNull] IEnumerable<object> entities);
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <returns></returns>
        int SaveChanges(bool acceptAllChangesOnSuccess);
        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns></returns>
        int SaveChanges();
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="acceptAllChangesOnSuccess">if set to <c>true</c> [accept all changes on success].</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        /// <summary>
        /// Saves the changes asynchronous.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        /// <summary>
        /// Sets the specified name.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>([NotNull] string name) where TEntity : class;
        /// <summary>
        /// Sets this instance.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <returns></returns>
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry Update([NotNull] object entity);
        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <typeparam name="TEntity">The type of the entity.</typeparam>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        EntityEntry<TEntity> Update<TEntity>([NotNull] TEntity entity) where TEntity : class;
        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange([NotNull] params object[] entities);
        /// <summary>
        /// Updates the range.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void UpdateRange([NotNull] IEnumerable<object> entities);

    }
}
