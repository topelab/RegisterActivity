using System;

namespace Tools.TogglData.Domain.Interfaces
{
    /// <summary>
    /// Interface for data part of Winlog
    /// </summary>
    public interface IWinlogData
    {
        /// <summary>
        /// Hash code
        /// </summary>
        int HashCode { get; set; }

        /// <summary>
        /// Program
        /// </summary>
        string Program { get; set; }

        /// <summary>
        /// Filename
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Start time
        /// </summary>
        string StartTime { get; set; }

        /// <summary>
        /// End time
        /// </summary>
        string EndTime { get; set; }

        /// <summary>
        /// Total time
        /// </summary>
        decimal TotalTime { get; set; }

        /// <summary>
        /// Exported
        /// </summary>
        int? Exported { get; set; }

    }
}
