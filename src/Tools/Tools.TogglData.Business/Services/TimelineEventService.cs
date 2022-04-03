using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topelab.Core.Helpers.Utils;
using Tools.TogglData.Adapters.Interfaces;
using Tools.TogglData.Business.Services.Interfaces;
using Tools.TogglData.Domain.Entities;

namespace Tools.TogglData.Business.Services
{
    /// <summary>
    /// TimelineEvent service
    /// </summary>
    public class TimelineEventService : ITimelineEventService
    {
        private readonly ILogService logService;

        /// <summary>
        /// The context database
        /// </summary>
        protected readonly ITogglDataDbContext context;

        /// <summary>
        /// Initializes a new instance of the TimelineEvent Service class.
        /// </summary>
        /// <param name="context">The context for service.</param>
        /// <param name="logService">The log service for service.</param>
        public TimelineEventService(ITogglDataDbContext context,
            ILogService logService)
        {
            this.logService = logService;
            this.context = context;
        }

    }
}