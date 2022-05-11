using Topelab.RegisterActivity.Adapters.Context;

namespace Topelab.RegisterActivity.Adapters.Interfaces
{
    /// <summary>
	/// Define implementation for IRegisterActivityDbContext factory
	/// </summary>
    public interface IRegisterActivityDbContextFactory
    {
        /// <summary>
        /// Create RegisterActivityDbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        RegisterActivityDbContext Create(string connectionStringLabel = "localserver");

        /// <summary>
        /// Create options for RegisterActivityDbContext from connection string
        /// </summary>
        /// <param name="connString">Connection string</param>
        RegisterActivityDbContext CreateFromConnectionString(string connString);
    }
}