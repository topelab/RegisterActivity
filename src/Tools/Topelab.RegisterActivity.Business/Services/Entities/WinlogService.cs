using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topelab.Core.Helpers.Utils;
using Topelab.RegisterActivity.Adapters.Interfaces;
using Topelab.RegisterActivity.Business.Services.Interfaces;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services.Entities
{
    /// <summary>
    /// Winlog service
    /// </summary>
    public class WinlogService : IWinlogService
    {
        private readonly ILogService logService;

        /// <summary>
        /// The context database
        /// </summary>
        protected readonly IRegisterActivityDbContext context;

        /// <summary>
        /// Initializes a new instance of the Winlog Service class.
        /// </summary>
        /// <param name="context">The context for service.</param>
        /// <param name="logService">The log service for service.</param>
        public WinlogService(IRegisterActivityDbContext context,
            ILogService logService)
        {
            this.logService = logService;
            this.context = context;
        }

    }
}