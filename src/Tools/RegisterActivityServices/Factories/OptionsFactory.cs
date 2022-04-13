using Microsoft.EntityFrameworkCore;
using Tools.TogglData.Adapters.Context;

namespace RegisterActivityServices.Factories
{
    public class OptionsFactory : IOptionsFactory
    {
        /// <summary>
        /// Create options for TogglDataFbContext
        /// </summary>
        /// <param name="connectionStringLabel">Label for connection string</param>
        public DbContextOptions<TogglDataDbContext> Create(string connectionStringLabel)
        {
            var connString = ConfigHelper.GetConnectionString(connectionStringLabel);
            return new DbContextOptionsBuilder<TogglDataDbContext>()
                .UseSqlite(connString)
                .Options;

        }
    }
}
