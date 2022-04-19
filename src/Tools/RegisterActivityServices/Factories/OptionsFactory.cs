using Microsoft.EntityFrameworkCore;
using Topelab.RegisterActivity.Adapters.Context;

namespace RegisterActivityServices.Factories
{
    public class OptionsFactory : IOptionsFactory
    {
        /// <summary>
        /// Create options for TogglDataFbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        public DbContextOptions<RegisterActivityDbContext> Create(string connectionStringLabel)
        {
            var connString = ConfigHelper.GetConnectionString(connectionStringLabel);
            return new DbContextOptionsBuilder<RegisterActivityDbContext>()
                .UseSqlite(connString)
                .Options;
        }
    }
}
