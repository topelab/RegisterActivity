using System;
using System.Collections.Generic;
using Tools.TogglData.Domain.Interfaces;
using Tools.TogglData.Domain.Collections;

namespace Tools.TogglData.Domain.Entities
{
    /// <summary>
    /// Implementation for Winlog
    /// </summary>
    public partial class Winlog : IWinlog
    {
        private int localId;
        private int hashCode;
        private string program;
        private string filename;
        private string title;
        private string startTime;
        private string endTime;
        private string totalTime;
        private int? exported;

        /// <summary>
        /// Constructor for Winlog
        /// </summary>
        public Winlog()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor for Winlog
        /// </summary>
        /// <param name="entity">IWinlog to get values for new Winlog</param>
        public Winlog(IWinlog entity)
        {
            localId = entity.LocalId;
            hashCode = entity.HashCode;
            program = entity.Program;
            filename = entity.Filename;
            title = entity.Title;
            startTime = entity.StartTime;
            endTime = entity.EndTime;
            totalTime = entity.TotalTime;
            exported = entity.Exported;

            Initialize();
        }

        // Atributos

        /// <summary>
        /// Local id
        /// </summary>
        public int LocalId
        {
            get => localId;
            set
            {
                if (localId != value)
                {
                    localId = value;
                    OnLocalIdChanged();
                }
            }
        }

        /// <summary>
        /// Called when LocalId changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnLocalIdChanged();

        /// <summary>
        /// Hash code
        /// </summary>
        public int HashCode
        {
            get => hashCode;
            set
            {
                if (hashCode != value)
                {
                    hashCode = value;
                    OnHashCodeChanged();
                }
            }
        }

        /// <summary>
        /// Called when HashCode changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnHashCodeChanged();

        /// <summary>
        /// Program
        /// </summary>
        public string Program
        {
            get => program;
            set
            {
                if (program != value)
                {
                    program = value;
                    OnProgramChanged();
                }
            }
        }

        /// <summary>
        /// Called when Program changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnProgramChanged();

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get => filename;
            set
            {
                if (filename != value)
                {
                    filename = value;
                    OnFilenameChanged();
                }
            }
        }

        /// <summary>
        /// Called when Filename changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnFilenameChanged();

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get => title;
            set
            {
                if (title != value)
                {
                    title = value;
                    OnTitleChanged();
                }
            }
        }

        /// <summary>
        /// Called when Title changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnTitleChanged();

        /// <summary>
        /// Start time
        /// </summary>
        public string StartTime
        {
            get => startTime;
            set
            {
                if (startTime != value)
                {
                    startTime = value;
                    OnStartTimeChanged();
                }
            }
        }

        /// <summary>
        /// Called when StartTime changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnStartTimeChanged();

        /// <summary>
        /// End time
        /// </summary>
        public string EndTime
        {
            get => endTime;
            set
            {
                if (endTime != value)
                {
                    endTime = value;
                    OnEndTimeChanged();
                }
            }
        }

        /// <summary>
        /// Called when EndTime changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnEndTimeChanged();

        /// <summary>
        /// Total time
        /// </summary>
        public string TotalTime
        {
            get => totalTime;
            set
            {
                if (totalTime != value)
                {
                    totalTime = value;
                    OnTotalTimeChanged();
                }
            }
        }

        /// <summary>
        /// Called when TotalTime changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnTotalTimeChanged();

        /// <summary>
        /// Exported
        /// </summary>
        public int? Exported
        {
            get => exported;
            set
            {
                if (exported != value)
                {
                    exported = value;
                    OnExportedChanged();
                }
            }
        }

        /// <summary>
        /// Called when Exported changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnExportedChanged();


        private void Initialize()
        {
            OnWinlogInitialized();
        }

        /// <summary>
        /// Called when Winlog initialized
        /// </summary>
        partial void OnWinlogInitialized();
    }
}
