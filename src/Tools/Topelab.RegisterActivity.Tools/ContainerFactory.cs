using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using Topelab.Core.Resolver.Entities;
using Topelab.Core.Resolver.Interfaces;
using Topelab.Core.Resolver.Microsoft;
using Topelab.RegisterActivity.Adapters.Context;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Adapters.SetupDI;
using Topelab.RegisterActivity.BaseBusiness.Actions;

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
                .AddCollection(AdaptersSetupDI.ModuleDependencies)
                .AddScoped<IRegisterActivityDbContextOptionsFactory, RegisterActivityDbContextOptionsFactory>()
                .AddFactory(s =>
                {
                    var factory = s.Get<ILoggerFactory>();
                    factory.AddProvider(new NLogLoggerProvider());
                    return factory.CreateLogger("Topelab.RegisterActivity.Tools");
                })
                .AddSelf<CreateAction>()
                .AddSelf<DeleteAction>()
                .AddSelf<MigrateAction>()
                .AddSelf<CanConnectAction>();
        }
    }
}