using System;
using Topelab.RegisterActivity.BaseBusiness.Actions;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
using Topelab.RegisterActivity.Tools.Actions;

namespace Topelab.RegisterActivity.Tools
{
    static class Program
    {
        static void Main(string[] args)
        {
            var arg = args.Length > 0 ? args[0] : "test";

            var resolver = ContainerFactory.Setup();
            var logger = resolver.Get<ILogService>();

            IAction action;
            switch (arg)
            {
                case "create":
                    logger.Info("Creating DB...");
                    action = resolver.Get<CreateAction>();
                    break;
                case "delete":
                    logger.Info("Deleting DB...");
                    action = resolver.Get<DeleteAction>();
                    break;
                case "migrate":
                    logger.Info("Migrating DB...");
                    action = resolver.Get<MigrateAction>();
                    break;
                case "join":
                    logger.Info("Joining DB...");
                    action = resolver.Get<JoinAction>();
                    break;
                case "export":
                    logger.Info("Exporting DB...");
                    action = resolver.Get<ExportAction>();
                    break;
                default:
                    logger.Info("Checking DB...");
                    action = resolver.Get<CanConnectAction>();
                    break;
            }

            if (args.Length > 0)
            {
                var started = action?.Start(args[1..]);
                if (started.HasValue && !started.Value && logger.HasErrors)
                {
                    Console.WriteLine(logger.LastError);
                }

                logger.Info($"Action realized: {started}");
            }
            else
            {
                var errorMessage = "No args specified";
                logger.Info(errorMessage);
                Console.WriteLine(errorMessage);
            }

        }
    }
}
