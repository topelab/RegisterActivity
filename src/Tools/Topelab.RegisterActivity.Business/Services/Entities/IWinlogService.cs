using System.Collections.Generic;
using Topelab.RegisterActivity.BaseBusiness.Services.Interfaces;
using Topelab.RegisterActivity.Business.DTO;
using Topelab.RegisterActivity.Domain.Entities;

namespace Topelab.RegisterActivity.Business.Services.Entities
{
    /// <summary>
    /// Winlog service
    /// </summary>
    public interface IWinlogService : IServiceDb
    {
        /// <summary>
        /// Get time line events from DB
        /// </summary>
        List<TimelineEventsDTO> GetTimeLineEvents();

        /// <summary>
        /// Save winlog data with new duration
        /// </summary>
        /// <param name="winlogToSave">Register to save</param>
        /// <returns>The Id for the saved record</returns>
        int Save(Winlog winlogToSave);
    }
}