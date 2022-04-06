using System;

namespace Tools.TogglData.Domain.Interfaces
{
    /// <summary>
    /// Interface for keys part of TimelineEvent
    /// </summary>
    public interface ITimelineEventKey
    {
        /// <summary>
        /// Local id
        /// </summary>
        int LocalId { get; set; }

    }
}
