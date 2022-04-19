using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Topelab.RegisterActivity.Domain.Dtos
{
    /// <summary>
    /// Criteria base DTO class.
    /// </summary>
    public class CriteriaBaseDto
    {
        /// <summary>
        /// Page number, 0 is first page.
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// Number of records in a page (50 by default), 0 = all.
        /// </summary>
        public int PageSize { get; set; } = 50;
    }

    /// <summary>
    /// Criteria DTO class.
    /// </summary>
    public class CriteriaDto : CriteriaBaseDto
    {
        /// <summary>
        /// Filter expression, ex. <code>x => x.Name.StartsWith("AB")</code>.
        /// </summary>
        public string Filter { get; set; }
        /// <summary>
        /// Order expression, ex. <code>cp-, name</code>.
        /// </summary>
        public string Order { get; set; }
    }

    /// <summary>
    /// Filter DTO class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class FilterDto<TEntity>
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public Expression<Func<TEntity, bool>> Filter { get; set; }
    }

    /// <summary>
    /// Order DTO class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class OrderDto<TEntity>
    {
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Expression<Func<TEntity, object>> Order { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="OrderDto{TEntity}"/> is descending.
        /// </summary>
        /// <value>
        ///   <c>true</c> if descending; otherwise, <c>false</c>.
        /// </value>
        public bool Descending { get; set; }
    }

    /// <summary>
    /// Criteria DTO for <typeparamref name="TEntity"/> class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class CriteriaDto<TEntity> : CriteriaBaseDto
        where TEntity : class
    {
        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public Expression<Func<TEntity, bool>> Filter { get; set; }
        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        public Expression<Func<TEntity, object>> Order { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CriteriaDto{TEntity}"/> is descending.
        /// </summary>
        /// <value>
        ///   <c>true</c> if descending; otherwise, <c>false</c>.
        /// </value>
        public bool Descending { get; set; }
    }

    /// <summary>
    /// Criteria with multiples filters and orders DTO class.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    public class CriteriaMultipleDto<TEntity> : CriteriaBaseDto
        where TEntity : class
    {
        /// <summary>
        /// Gets or sets the filters.
        /// </summary>
        public IEnumerable<FilterDto<TEntity>> Filters { get; set; }
        /// <summary>
        /// Gets or sets the orders.
        /// </summary>
        public IEnumerable<OrderDto<TEntity>> Orders { get; set; }
    }
}
