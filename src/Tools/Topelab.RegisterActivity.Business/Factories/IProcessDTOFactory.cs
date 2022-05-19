using System;
using System.Diagnostics;
using Topelab.RegisterActivity.Business.DTO;

namespace Topelab.RegisterActivity.Business.Factories
{
    public interface IProcessDTOFactory
    {
        ProcessDTO Create(Process p, string defaultTitle, DateTime when, double msToDiscount = 0);
    }
}