using Microsoft.Extensions.Logging;
using System;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Business.Actions
{
    public class DeleteAction : BaseAction
    {
        public DeleteAction(IRegisterActivityDbContextFactory dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }

        public override bool Start(string[] args = null)
        {
            using var db = dbContextFactory.Create();
            try
            {
                logger.LogInformation("Trying to delete database on {ProviderName}", db.Database.ProviderName);
                bool deleted = db.Database.EnsureDeleted();
                logger.LogInformation("Database {deleted}",  deleted ? "was deleted" : "can not be deleted");

                return deleted;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error on start DeleteAction");
            }

            return false;
        }
    }
}
