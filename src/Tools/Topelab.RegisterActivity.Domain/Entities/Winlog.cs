using System;
using Topelab.RegisterActivity.Domain.Interfaces;
using Topelab.RegisterActivity.Domain.Collections;

namespace Topelab.RegisterActivity.Domain.Entities
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
        private int totalTime;
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

        /************ Properties *************/

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
        /// Total time
        /// </summary>
        public int TotalTime
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

        private void Initialize()
        {
            OnInitialized();
        }

        partial void OnInitialized();

        partial void OnLocalIdChanged();
        partial void OnHashCodeChanged();
        partial void OnProgramChanged();
        partial void OnFilenameChanged();
        partial void OnTitleChanged();
        partial void OnStartTimeChanged();
        partial void OnEndTimeChanged();
        partial void OnTotalTimeChanged();
        partial void OnExportedChanged();

    }
}
