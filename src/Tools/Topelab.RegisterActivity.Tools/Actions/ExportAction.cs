using System;
using System.IO;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.BaseBusiness.Actions;
using Topelab.RegisterActivity.BaseBusiness.Enums;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
using Topelab.RegisterActivity.Business.Enums;
using Topelab.RegisterActivity.Business.Services;

namespace Topelab.RegisterActivity.Tools.Actions
{
    internal class ExportAction(IExportDataService exportDataService, IRegisterActivityDbContextFactory dbContextFactory, ILogService logService) : BaseAction(dbContextFactory, logService)
    {
        public override bool Start(string[] args = null)
        {
            ArgumentNullException.ThrowIfNull(args);

            if (args.Length < 1)
            {
                logService.Error("You need almost 1 argument to export activities DB\nSyntax: export Path-To-DB-File-Without-Extension Excel|CSV Output-Directory Output-FileName");
                return false;
            }

            var result = true;

            string outputFile = args[0];
            ExportFormat exportFormat = args.Length > 1 && Enum.TryParse(args[1], out exportFormat) ? exportFormat : ExportFormat.CSV;
            string outputDirectory = args.Length > 2 ? args[2] : Path.GetDirectoryName(outputFile);
            string outFileName = args.Length > 3 ? args[3] : $"ActivitiesDB-{Environment.MachineName}";

            try
            {
                Environment.SetEnvironmentVariable(Constants.OutputFile, outputFile);
                Environment.SetEnvironmentVariable(Constants.Year, DateTime.Today.ToString("yyyy"));
                Environment.SetEnvironmentVariable(Constants.Month, DateTime.Today.ToString("MM"));
                Environment.SetEnvironmentVariable(Constants.Day, DateTime.Today.ToString("dd"));
                Environment.SetEnvironmentVariable(Constants.OutputDirectory, outputDirectory);
                Environment.SetEnvironmentVariable(Constants.OutputFileName, outFileName);
                exportDataService.Start(exportFormat);
            }
            catch (Exception ex)
            {
                logService.Error($"Export has failed: {ex.Message}");
                result = false;
            }

            return result;
        }
    }
}
