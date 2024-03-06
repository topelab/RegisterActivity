using System;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.BaseBusiness.Actions;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Tools.Actions
{
    internal class JoinAction(IJoinService joinService, IRegisterActivityDbContextFactory dbContextFactory, ILogService logService) : BaseAction(dbContextFactory, logService)
    {
        public override bool Start(string[] args = null)
        {
            ArgumentNullException.ThrowIfNull(args);

            if (args.Length < 2)
            {
                logService.Error("You need at least 2 arguments to join activities DB into one ActivityDB.\nSYNTAX: join InputPathPattern OutputFile [true|*false]\nLast argument controls if OutputFile needs to be created");
                return false;
            }

            bool create = args.Length > 2 ? (bool.TryParse(args[2], out create) ? create : false) : false;

            bool result = true;
            try
            {
                joinService.Start(args[0], args[1], create);
            }
            catch (Exception ex)
            {
                logService.Error($"Join has failed: {ex.Message}");
                result = false;
            }

            return result;
        }
    }
}
