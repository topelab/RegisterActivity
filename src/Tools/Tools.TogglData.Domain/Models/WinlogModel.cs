using System;
using Tools.TogglData.Domain.Base;
using Tools.TogglData.Domain.Interfaces;

namespace Tools.TogglData.Domain.Models
{
    /// <summary>
    /// Implementation for Winlog model
    /// </summary>
    public partial class WinlogModel : BaseModel<IWinlog>, IWinlog
    {
        private int localId;
        private int hashCode;
        private string program;
        private string filename;
        private string title;
        private string startTime;
        private string endTime;
        private decimal totalTime;
        private int? exported;

        /// <summary>
        /// Constructor for Winlog
        /// </summary>
        public WinlogModel()
        {
        }

        /// <summary>
        /// Constructor for Winlog
        /// </summary>
        /// <param name="entity">IWinlog to get values for new Winlog</param>
        public WinlogModel(IWinlog entity)
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
        }

        /// <summary>
        /// Local id
        /// </summary>
        public int LocalId
        {
            get => localId;
            set => SetProperty(ref localId, value, OnLocalIdChanged, CanLocalIdChange);
        }

        /// <summary>
        /// Hash code
        /// </summary>
        public int HashCode
        {
            get => hashCode;
            set => SetProperty(ref hashCode, value, OnHashCodeChanged, CanHashCodeChange);
        }

        /// <summary>
        /// Program
        /// </summary>
        public string Program
        {
            get => program;
            set => SetProperty(ref program, value, OnProgramChanged, CanProgramChange);
        }

        /// <summary>
        /// Filename
        /// </summary>
        public string Filename
        {
            get => filename;
            set => SetProperty(ref filename, value, OnFilenameChanged, CanFilenameChange);
        }

        /// <summary>
        /// Title
        /// </summary>
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value, OnTitleChanged, CanTitleChange);
        }

        /// <summary>
        /// Start time
        /// </summary>
        public string StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value, OnStartTimeChanged, CanStartTimeChange);
        }

        /// <summary>
        /// End time
        /// </summary>
        public string EndTime
        {
            get => endTime;
            set => SetProperty(ref endTime, value, OnEndTimeChanged, CanEndTimeChange);
        }

        /// <summary>
        /// Total time
        /// </summary>
        public decimal TotalTime
        {
            get => totalTime;
            set => SetProperty(ref totalTime, value, OnTotalTimeChanged, CanTotalTimeChange);
        }

        /// <summary>
        /// Exported
        /// </summary>
        public int? Exported
        {
            get => exported;
            set => SetProperty(ref exported, value, OnExportedChanged, CanExportedChange);
        }

        /// <summary>
        /// Test if LocalId can change its value
        /// </summary>
        public Func<IWinlog, int, bool> CanLocalIdChange { get; set; }
        /// <summary>
        /// Action triggered after LocalId changed its value
        /// </summary>
        public Action<int> OnLocalIdChanged { get; set; }

        /// <summary>
        /// Test if HashCode can change its value
        /// </summary>
        public Func<IWinlog, int, bool> CanHashCodeChange { get; set; }
        /// <summary>
        /// Action triggered after HashCode changed its value
        /// </summary>
        public Action<int> OnHashCodeChanged { get; set; }

        /// <summary>
        /// Test if Program can change its value
        /// </summary>
        public Func<IWinlog, string, bool> CanProgramChange { get; set; }
        /// <summary>
        /// Action triggered after Program changed its value
        /// </summary>
        public Action<string> OnProgramChanged { get; set; }

        /// <summary>
        /// Test if Filename can change its value
        /// </summary>
        public Func<IWinlog, string, bool> CanFilenameChange { get; set; }
        /// <summary>
        /// Action triggered after Filename changed its value
        /// </summary>
        public Action<string> OnFilenameChanged { get; set; }

        /// <summary>
        /// Test if Title can change its value
        /// </summary>
        public Func<IWinlog, string, bool> CanTitleChange { get; set; }
        /// <summary>
        /// Action triggered after Title changed its value
        /// </summary>
        public Action<string> OnTitleChanged { get; set; }

        /// <summary>
        /// Test if StartTime can change its value
        /// </summary>
        public Func<IWinlog, string, bool> CanStartTimeChange { get; set; }
        /// <summary>
        /// Action triggered after StartTime changed its value
        /// </summary>
        public Action<string> OnStartTimeChanged { get; set; }

        /// <summary>
        /// Test if EndTime can change its value
        /// </summary>
        public Func<IWinlog, string, bool> CanEndTimeChange { get; set; }
        /// <summary>
        /// Action triggered after EndTime changed its value
        /// </summary>
        public Action<string> OnEndTimeChanged { get; set; }

        /// <summary>
        /// Test if TotalTime can change its value
        /// </summary>
        public Func<IWinlog, decimal, bool> CanTotalTimeChange { get; set; }
        /// <summary>
        /// Action triggered after TotalTime changed its value
        /// </summary>
        public Action<decimal> OnTotalTimeChanged { get; set; }

        /// <summary>
        /// Test if Exported can change its value
        /// </summary>
        public Func<IWinlog, int?, bool> CanExportedChange { get; set; }
        /// <summary>
        /// Action triggered after Exported changed its value
        /// </summary>
        public Action<int?> OnExportedChanged { get; set; }
    }
}
