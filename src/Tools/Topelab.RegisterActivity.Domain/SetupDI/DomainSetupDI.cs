using Topelab.Core.Resolver.Entities;
using Topelab.RegisterActivity.Domain.Factories;

namespace Topelab.RegisterActivity.Domain.SetupDI
{
    /// <summary>
    /// Di Services
    /// </summary>
    public static class DomainSetupDI
    {
        /// <summary>
        /// Module dependencies to init on DI module
        /// </summary>
        public static ResolveInfoCollection ModuleDependencies => BaseDependencies();

        private static ResolveInfoCollection BaseDependencies()
        {
            return new ResolveInfoCollection()
                .AddSingleton<ICommandFactory, CommandFactory>();
        }
    }
}
