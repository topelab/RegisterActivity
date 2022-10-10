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
            set => SetProperty(ref localId, value, OnLocalIdChanged, whenLocalIdCanChange);
        }

        /// <summary>
        /// Hash code
        /// </summary>
        public int HashCode
        {
            get => hashCode;
            set => SetProperty(ref hashCode, value, OnHashCodeChanged, whenHashCodeCanChange);
        }

        /// <summary>
        /// Program
        /// </summary>
        public string Program
        {
            get => program;
            set => SetProperty(ref program, value, OnProgramChanged, whenProgramCanChange);
        }

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get => filename;
            set => SetProperty(ref filename, value, OnFilenameChanged, whenFilenameCanChange);
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value, OnTitleChanged, whenTitleCanChange);
        }

        /// <summary>
        /// Start time
        /// </summary>
        public string StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value, OnStartTimeChanged, whenStartTimeCanChange);
        }

        /// <summary>
        /// End time
        /// </summary>
        public string EndTime
        {
            get => endTime;
            set => SetProperty(ref endTime, value, OnEndTimeChanged, whenEndTimeCanChange);
        }

        /// <summary>
        /// Total time
        /// </summary>
        public int TotalTime
        {
            get => totalTime;
            set => SetProperty(ref totalTime, value, OnTotalTimeChanged, whenTotalTimeCanChange);
        }

        /// <summary>
        /// Exported
        /// </summary>
        public int? Exported
        {
            get => exported;
            set => SetProperty(ref exported, value, OnExportedChanged, whenExportedCanChange);
        }

        private void Initialize()
        {
            OnInitialized();
            OnInitialized(this);
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
