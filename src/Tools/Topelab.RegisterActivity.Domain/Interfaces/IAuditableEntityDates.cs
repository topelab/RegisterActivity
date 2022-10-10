using System;

namespace Topelab.RegisterActivity.Domain.Interfaces
{
    /// <summary>
    /// Auditable entity with creation date and modification date
    /// </summary>
    public interface IAuditableEntityDates : IAuditableEntityCreationDate
    {
        /// <summary>
        /// Updated date
        /// </summary>
        DateTime? UpdateDate { get; set; }
    }
}
