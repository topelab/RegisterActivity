using Microsoft.Extensions.Logging;
using System;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Tools.Actions
{
    public class CreateAction : BaseAction
    {
        public CreateAction(IRegisterActivityDbContextFactory dbContextFactory, ILogger logger) : base(dbContextFactory, logger)
        {
        }

        public override bool Start(string[] args = null)
        {
            using var db = dbContextFactory.Create();
            try
            {
                logger.LogInformation("Trying to create database on {ProviderName}", db.Database.ProviderName);
                var created = db.Database.EnsureCreated();
                logger.LogInformation("Database {Created}", created ? "was created" : "already exists");

                return created;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error on start CreateAction");
            }

            return false;
        }
    }
}
