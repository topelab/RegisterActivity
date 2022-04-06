using System;

namespace Tools.TogglData.Domain.Interfaces
{
    /// <summary>
    /// Interface for data part of TimelineEvent
    /// </summary>
    public interface ITimelineEventData
    {
        /// <summary>
        /// Guid
        /// </summary>
        string Guid { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        string Title { get; set; }

        /// <summary>
        /// Filename
        /// </summary>
        string Filename { get; set; }

        /// <summary>
        /// Uid
        /// </summary>
        int Uid { get; set; }

        /// <summary>
        /// Start time
        /// </summary>
        int StartTime { get; set; }

        /// <summary>
        /// End time
        /// </summary>
        int? EndTime { get; set; }

        /// <summary>
        /// Idle
        /// </summary>
        int Idle { get; set; }

        /// <summary>
        /// Uploaded
        /// </summary>
        int Uploaded { get; set; }

        /// <summary>
        /// Chunked
        /// </summary>
        int Chunked { get; set; }

    }
}
