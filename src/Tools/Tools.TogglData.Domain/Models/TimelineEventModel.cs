using System;
using Tools.TogglData.Domain.Base;
using Tools.TogglData.Domain.Interfaces;

namespace Tools.TogglData.Domain.Models
{
    /// <summary>
    /// Implementation for Timeline event model
    /// </summary>
    public partial class TimelineEventModel : BaseModel<ITimelineEvent>, ITimelineEvent
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
        public TimelineEventModel()
        {
        }

        /// <summary>
        /// Constructor for Timeline event
        /// </summary>
        /// <param name="entity">ITimelineEvent to get values for new TimelineEvent</param>
        public TimelineEventModel(ITimelineEvent entity)
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
        /// Guid
        /// </summary>
        public string Guid
        {
            get => guid;
            set => SetProperty(ref guid, value, OnGuidChanged, CanGuidChange);
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
        /// Filename
        /// </summary>
        public string Filename
        {
            get => filename;
            set => SetProperty(ref filename, value, OnFilenameChanged, CanFilenameChange);
        }

        /// <summary>
        /// Uid
        /// </summary>
        public int Uid
        {
            get => uid;
            set => SetProperty(ref uid, value, OnUidChanged, CanUidChange);
        }

        /// <summary>
        /// Start time
        /// </summary>
        public int StartTime
        {
            get => startTime;
            set => SetProperty(ref startTime, value, OnStartTimeChanged, CanStartTimeChange);
        }

        /// <summary>
        /// End time
        /// </summary>
        public int? EndTime
        {
            get => endTime;
            set => SetProperty(ref endTime, value, OnEndTimeChanged, CanEndTimeChange);
        }

        /// <summary>
        /// Idle
        /// </summary>
        public int Idle
        {
            get => idle;
            set => SetProperty(ref idle, value, OnIdleChanged, CanIdleChange);
        }

        /// <summary>
        /// Uploaded
        /// </summary>
        public int Uploaded
        {
            get => uploaded;
            set => SetProperty(ref uploaded, value, OnUploadedChanged, CanUploadedChange);
        }

        /// <summary>
        /// Chunked
        /// </summary>
        public int Chunked
        {
            get => chunked;
            set => SetProperty(ref chunked, value, OnChunkedChanged, CanChunkedChange);
        }

        /// <summary>
        /// Test if LocalId can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanLocalIdChange { get; set; }
        /// <summary>
        /// Action triggered after LocalId changed its value
        /// </summary>
        public Action<int> OnLocalIdChanged { get; set; }

        /// <summary>
        /// Test if Guid can change its value
        /// </summary>
        public Func<ITimelineEvent, string, bool> CanGuidChange { get; set; }
        /// <summary>
        /// Action triggered after Guid changed its value
        /// </summary>
        public Action<string> OnGuidChanged { get; set; }

        /// <summary>
        /// Test if Title can change its value
        /// </summary>
        public Func<ITimelineEvent, string, bool> CanTitleChange { get; set; }
        /// <summary>
        /// Action triggered after Title changed its value
        /// </summary>
        public Action<string> OnTitleChanged { get; set; }

        /// <summary>
        /// Test if Filename can change its value
        /// </summary>
        public Func<ITimelineEvent, string, bool> CanFilenameChange { get; set; }
        /// <summary>
        /// Action triggered after Filename changed its value
        /// </summary>
        public Action<string> OnFilenameChanged { get; set; }

        /// <summary>
        /// Test if Uid can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanUidChange { get; set; }
        /// <summary>
        /// Action triggered after Uid changed its value
        /// </summary>
        public Action<int> OnUidChanged { get; set; }

        /// <summary>
        /// Test if StartTime can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanStartTimeChange { get; set; }
        /// <summary>
        /// Action triggered after StartTime changed its value
        /// </summary>
        public Action<int> OnStartTimeChanged { get; set; }

        /// <summary>
        /// Test if EndTime can change its value
        /// </summary>
        public Func<ITimelineEvent, int?, bool> CanEndTimeChange { get; set; }
        /// <summary>
        /// Action triggered after EndTime changed its value
        /// </summary>
        public Action<int?> OnEndTimeChanged { get; set; }

        /// <summary>
        /// Test if Idle can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanIdleChange { get; set; }
        /// <summary>
        /// Action triggered after Idle changed its value
        /// </summary>
        public Action<int> OnIdleChanged { get; set; }

        /// <summary>
        /// Test if Uploaded can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanUploadedChange { get; set; }
        /// <summary>
        /// Action triggered after Uploaded changed its value
        /// </summary>
        public Action<int> OnUploadedChanged { get; set; }

        /// <summary>
        /// Test if Chunked can change its value
        /// </summary>
        public Func<ITimelineEvent, int, bool> CanChunkedChange { get; set; }
        /// <summary>
        /// Action triggered after Chunked changed its value
        /// </summary>
        public Action<int> OnChunkedChanged { get; set; }
    }
}
