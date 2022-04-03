using Microsoft.EntityFrameworkCore;
using Tools.TogglData.Domain.Entities;

namespace Tools.TogglData.Adapters.Interfaces
{
    /// <summary>
    /// Interface for TogglData DbContext
    /// </summary>
    /// <seealso cref="DbContext" />
    public interface ITogglDataDbContext : IDbContext
    {
        /// <summary>TogglData DbContext Id</summary>
        int Id { get; }
        /// <summary>DbSet for TimelineEvent</summary>
        DbSet<TimelineEvent> TimelineEvent { get; set; }
        /// <summary>DbSet for Winlog</summary>
        DbSet<Winlog> Winlog { get; set; }

    }
}
