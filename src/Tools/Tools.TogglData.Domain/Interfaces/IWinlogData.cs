using System;

namespace Tools.TogglData.Domain.Interfaces
{
    /// <summary>
    /// Interface for data part of Winlog
    /// </summary>
    public interface IWinlogData
    {
        /// <summary>
        /// Local id
        /// </summary>
        int LocalId { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Filename
        /// </summary>
        string Filename { get; set; }

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
        string TotalTime { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        string Date { get; set; }

        /// <summary>
        /// Program
        /// </summary>
        string Program { get; set; }

    }
}
