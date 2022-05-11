using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Topelab.Core.Resolver.Entities;
using Topelab.Core.Resolver.Interfaces;
using Topelab.Core.Resolver.Microsoft;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Tools.Actions;

namespace Topelab.RegisterActivity.Tools
{
    public static class ContainerFactory
    {
        /// <summary>
        /// Setup container
        /// </summary>
        public static IResolver Setup()
        {
            return ResolverFactory.Create(GetCollection());
        }

        private static ResolveInfoCollection GetCollection()
        {
            return new ResolveInfoCollection()
                .AddScoped<ILoggerFactory, LoggerFactory>()
                .AddFactory(s => GetLogger(s))
                .AddScoped<IRegisterActivityDbContextFactory, RegisterActivityDbContextFactory>()
                .AddSelf<CreateAction>()
                .AddSelf<MigrateAction>()
                .AddSelf<CanConnectAction>();
        }

        private static ILogger GetLogger(IResolver resolver)
        {
            var factory = resolver.Get<ILoggerFactory>();
            factory.AddProvider(new NLogLoggerProvider());
            return factory.CreateLogger("Topelab.RegisterActivity.Tools");
        }
    }
}