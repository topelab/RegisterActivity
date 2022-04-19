using Microsoft.EntityFrameworkCore;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Adapters.Interfaces
{
    /// <summary>
    /// Interface for RegisterActivity DbContext
    /// </summary>
    /// <seealso cref="DbContext" />
    public interface IRegisterActivityDbContext : IDbContext
    {
        /// <summary>RegisterActivity DbContext Id</summary>
        int Id { get; }
        /// <summary>DbSet for Winlog</summary>
        DbSet<Winlog> Winlog { get; set; }

    }
}
