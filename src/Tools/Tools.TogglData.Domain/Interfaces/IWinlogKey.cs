using System;

namespace Tools.TogglData.Domain.Interfaces
{
    /// <summary>
    /// Interface for keys part of Winlog
    /// </summary>
    public interface IWinlogKey
    {
        /// <summary>
        /// Local id
        /// </summary>
        int LocalId { get; set; }

    }
}
