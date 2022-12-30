using Microsoft.Extensions.Logging;
using Topelab.RegisterActivity.Adapters.Interfaces;

namespace Topelab.RegisterActivity.Business.Actions
{
    public abstract class BaseAction : IAction
    {
        protected readonly IRegisterActivityDbContextFactory dbContextFactory;
        protected readonly ILogger logger;

        public BaseAction(IRegisterActivityDbContextFactory dbContextFactory, ILogger logger)
        {
            this.dbContextFactory = dbContextFactory;
            this.logger = logger;
        }

        public virtual bool Start(string[] args = null)
        {
            return true;
        }
    }
}
