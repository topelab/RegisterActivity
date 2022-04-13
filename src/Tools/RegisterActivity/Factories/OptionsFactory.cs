using Microsoft.EntityFrameworkCore;
using Tools.TogglData.Adapters.Context;

namespace RegisterActivity.Factories
{
    internal class OptionsFactory : IOptionsFactory
    {
        /// <summary>
        /// Create options for TogglDataFbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        public DbContextOptions<TogglDataDbContext> Create(string connectionStringLabel)
        {
            string connString = ConfigHelper.GetConnectionString(connectionStringLabel);
            return new DbContextOptionsBuilder<TogglDataDbContext>()
                .UseSqlite(connString)
                .Options;

        }
    }
}
