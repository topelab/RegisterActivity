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
            bool result = true;

            if (args.Length < 2)
            {
                logService.Error("You need 2 arguments to join activities DB into one ActivityDB");
                return false;
            }

            try
            {
                joinService.Start(args[0], args[1]);
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
