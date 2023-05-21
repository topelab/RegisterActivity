using Microsoft.Extensions.Logging;
using Topelab.RegisterActivity.Business.Actions;

namespace Topelab.RegisterActivity.Tools
{
    static class Program
    {
        static void Main(string[] args)
        {
            var arg = args.Length > 0 ? args[0] : "test";

            var resolver = ContainerFactory.Setup();
            var logger = resolver.Get<ILogger>();

            IAction action;
            switch (arg)
            {
                case "create":
                    logger.LogInformation("Creating DB...");
                    action = resolver.Get<CreateAction>();
                    break;
                case "delete":
                    logger.LogInformation("Deleting DB...");
                    action = resolver.Get<DeleteAction>();
                    break;
                case "migrate":
                    logger.LogInformation("Migrating DB...");
                    action = resolver.Get<MigrateAction>();
                    break;
                default:
                    logger.LogInformation("Checking DB...");
                    action = resolver.Get<CanConnectAction>();
                    break;
            }

            var started = action?.Start();
            logger.LogInformation("Action realized: {Started}", started);
        }
    }
}
