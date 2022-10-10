using Microsoft.EntityFrameworkCore;
using Topelab.RegisterActivity.Adapters.Context;

namespace Topelab.RegisterActivity.Adapters.Interfaces
{
    /// <summary>
    /// Defines interface for Db Context Options factory for RegisterActivity
    /// </summary>
    public interface IRegisterActivityDbContextOptionsFactory
    {
        /// <summary>
        /// Create options for RegisterActivityDbContext from connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        DbContextOptions<RegisterActivityDbContext> Create(string connString);
    }
}