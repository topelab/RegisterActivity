using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Tools.Actions
{
    public class MigrateAction : BaseAction
    {
        public MigrateAction(IRegisterActivityDbContextFactory dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }

        public override bool Start(string[] args = null)
        {
            using var db = dbContextFactory.Create();
            try
            {
                logger.LogInformation("Trying to migrate database on {ProviderName}", db.Database.ProviderName);
                db.Database.Migrate();
                logger.LogInformation("Database was migrated");

                return true;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error on start MigrateAction");
            }

            return false;
        }
    }
}
