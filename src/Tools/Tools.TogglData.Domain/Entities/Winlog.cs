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
        private string title;
        private string filename;
        private string startTime;
        private string endTime;
        private string totalTime;
        private string date;
        private string program;
        private int? hashCode;

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
            title = entity.Title;
            filename = entity.Filename;
            startTime = entity.StartTime;
            endTime = entity.EndTime;
            totalTime = entity.TotalTime;
            date = entity.Date;
            program = entity.Program;
            hashCode = entity.HashCode;

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
        /// Date
        /// </summary>
        public string Date
        {
            get => date;
            set
            {
                if (date != value)
                {
                    date = value;
                    OnDateChanged();
                }
            }
        }

        /// <summary>
        /// Called when Date changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnDateChanged();

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
        /// Hash code
        /// </summary>
        public int? HashCode
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
