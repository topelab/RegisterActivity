using Microsoft.EntityFrameworkCore;
using Topelab.RegisterActivity.Adapters.Context;

namespace RegisterActivityServices.Factories
{
    public interface IOptionsFactory
    {
        /// <summary>
        /// Create options for TogglDataFbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        DbContextOptions<RegisterActivityDbContext> Create(string connectionStringLabel);
    }
}