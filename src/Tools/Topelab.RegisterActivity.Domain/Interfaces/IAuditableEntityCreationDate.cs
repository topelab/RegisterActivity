using System;

namespace Topelab.RegisterActivity.Domain.Interfaces
{
    /// <summary>
    /// Audit entity with creation date
    /// </summary>
    public interface IAuditableEntityCreationDate
    {
        /// <summary>
        /// Creation date
        /// </summary>
        DateTime CreationDate { get; set; }
    }
}
