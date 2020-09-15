using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class TimelineEvents
    {
        public long LocalId { get; set; }
        public string Guid { get; set; }
        public string Title { get; set; }
        public string Filename { get; set; }
        public long Uid { get; set; }
        public long StartTime { get; set; }
        public long? EndTime { get; set; }
        public long Idle { get; set; }
        public long Uploaded { get; set; }
        public long Chunked { get; set; }

        public virtual Users U { get; set; }
    }
}
