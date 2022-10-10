using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using Topelab.RegisterActivity.Domain.Interfaces;

namespace Topelab.RegisterActivity.Adapters.Extensions
{
    /// <summary>
    /// IAuditableEntity extensions
    /// </summary>
    public static class EntityEntryExtensions
    {
        /// <summary>
        /// Update dates for an entity entry
        /// </summary>
        /// <param name="entityEntry">Entity entry to check auditable dates properties</param>
        public static void UpdateDates(this EntityEntry entityEntry)
        {
            if (entityEntry.State == EntityState.Added && entityEntry.Entity is IAuditableEntityCreationDate auditableWithCreationDate)
            {
                auditableWithCreationDate.CreationDate = DateTime.Now;
            }

            if (entityEntry.State == EntityState.Modified && entityEntry.Entity is IAuditableEntityDates auditableWithUpdateDate)
            {
                auditableWithUpdateDate.UpdateDate = DateTime.Now;
            }
        }
    }
}
