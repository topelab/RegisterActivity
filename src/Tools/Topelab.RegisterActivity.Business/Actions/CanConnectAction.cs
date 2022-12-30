using Microsoft.Extensions.Logging;
using System;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Business.Actions
{
    public class CanConnectAction : BaseAction
    {
        public CanConnectAction(IRegisterActivityDbContextFactory dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }

        public override bool Start(string[] args = null)
        {
            using var db = dbContextFactory.Create();
            try
            {
                logger.LogInformation("Trying to connect to database on {ProviderName}", db.Database.ProviderName);
                var canConnect = db.Database.CanConnect();
                logger.LogInformation("Database {Connected}", canConnect ? "can be connected" : "not exists");

                return canConnect;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error on start CanConnectAction");
            }

            return false;
        }
    }
}
