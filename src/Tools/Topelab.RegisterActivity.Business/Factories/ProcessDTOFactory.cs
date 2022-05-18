using System;
using System.Diagnostics;
using Topelab.RegisterActivity.Business.DTO;

namespace Topelab.RegisterActivity.Business.Factories
{
    public class ProcessDTOFactory : IProcessDTOFactory
    {
        public ProcessDTO Create(Process p, string defaultTitle, DateTime when, double msToDiscount = 0)
        {
            ProcessDTO processDTO = new()
            {
                Id = p.Id,
                MainWindowHandle = p.MainWindowHandle,
                MainWindowTitle = string.IsNullOrWhiteSpace(p.MainWindowTitle) ? defaultTitle : p.MainWindowTitle,
                ProcessName = p.ProcessName
            };
            var discount = p.StartTime > when.AddMilliseconds(-msToDiscount) ? (when - p.StartTime).TotalMilliseconds : msToDiscount;
            processDTO.LastTimeActive = when.AddMilliseconds(-discount);
            processDTO.Discount = discount;
            processDTO.StartTime = processDTO.LastTimeActive.Value;
            try
            {
                processDTO.FileName = p.MainModule.FileName;
            }
            catch
            {
            }

            return processDTO;
        }


    }
}
