using System;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.BaseBusiness.Actions;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services.Interfaces;

namespace Topelab.RegisterActivity.Tools.Actions
{
    internal class SplitAction(ISplitService splitService, IRegisterActivityDbContextFactory dbContextFactory, ILogService logService) : BaseAction(dbContextFactory, logService)
    {
        public override bool Start(string[] args = null)
        {
            ArgumentNullException.ThrowIfNull(args);

            if (args.Length < 2)
            {
                logService.Error("You need at least 2 arguments to join activities DB into one ActivityDB.\nSYNTAX: split InputFile OutputFile [Yearly*|Monthly]\nLast argument controls splitting type to be created");
                return false;
            }

            SplitType splitType = args.Length > 2 ? (Enum.TryParse(args[2], out splitType) ? splitType : SplitType.Yearly) : SplitType.Yearly;

            bool result = true;
            try
            {
                splitService.Start(args[0], args[1], splitType);
            }
            catch (Exception ex)
            {
                logService.Error($"Split has failed: {ex.Message}");
                result = false;
            }

            return result;
        }
    }
}
