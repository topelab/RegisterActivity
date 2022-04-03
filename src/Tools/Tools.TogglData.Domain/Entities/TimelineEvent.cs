using System;
using System.Collections.Generic;
using Tools.TogglData.Domain.Interfaces;
using Tools.TogglData.Domain.Collections;

namespace Tools.TogglData.Domain.Entities
{
    /// <summary>
    /// Implementation for Timeline event
    /// </summary>
    public partial class TimelineEvent : ITimelineEvent
    {
        private int localId;
        private string guid;
        private string title;
        private string filename;
        private int uid;
        private int startTime;
        private int? endTime;
        private int idle;
        private int uploaded;
        private int chunked;

        /// <summary>
        /// Constructor for Timeline event
        /// </summary>
        public TimelineEvent()
        {
            Initialize();
        }

        /// <summary>
        /// Constructor for Timeline event
        /// </summary>
        /// <param name="entity">ITimelineEvent to get values for new TimelineEvent</param>
        public TimelineEvent(ITimelineEvent entity)
        {
            localId = entity.LocalId;
            guid = entity.Guid;
            title = entity.Title;
            filename = entity.Filename;
            uid = entity.Uid;
            startTime = entity.StartTime;
            endTime = entity.EndTime;
            idle = entity.Idle;
            uploaded = entity.Uploaded;
            chunked = entity.Chunked;

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
        /// Guid
        /// </summary>
        public string Guid
        {
            get => guid;
            set
            {
                if (guid != value)
                {
                    guid = value;
                    OnGuidChanged();
                }
            }
        }

        /// <summary>
        /// Called when Guid changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnGuidChanged();

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
        /// Uid
        /// </summary>
        public int Uid
        {
            get => uid;
            set
            {
                if (uid != value)
                {
                    uid = value;
                    OnUidChanged();
                }
            }
        }

        /// <summary>
        /// Called when Uid changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnUidChanged();

        /// <summary>
        /// Start time
        /// </summary>
        public int StartTime
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
        public int? EndTime
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
        /// Idle
        /// </summary>
        public int Idle
        {
            get => idle;
            set
            {
                if (idle != value)
                {
                    idle = value;
                    OnIdleChanged();
                }
            }
        }

        /// <summary>
        /// Called when Idle changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnIdleChanged();

        /// <summary>
        /// Uploaded
        /// </summary>
        public int Uploaded
        {
            get => uploaded;
            set
            {
                if (uploaded != value)
                {
                    uploaded = value;
                    OnUploadedChanged();
                }
            }
        }

        /// <summary>
        /// Called when Uploaded changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnUploadedChanged();

        /// <summary>
        /// Chunked
        /// </summary>
        public int Chunked
        {
            get => chunked;
            set
            {
                if (chunked != value)
                {
                    chunked = value;
                    OnChunkedChanged();
                }
            }
        }

        /// <summary>
        /// Called when Chunked changed its value
        /// </summary>
        /// <returns></returns>
        partial void OnChunkedChanged();


        private void Initialize()
        {
            OnTimelineEventInitialized();
        }

        /// <summary>
        /// Called when TimelineEvent initialized
        /// </summary>
        partial void OnTimelineEventInitialized();
    }
}
