using System;
using System.Collections.Generic;
using System.IO;

namespace TogglData.dto
{
    public partial class TimelineEventsDTO
    {
        public long LocalId { get; set; }
        public string Title { get; set; }
        public string Filename { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double TotalTime => EndTime.HasValue ? (EndTime.Value - StartTime).TotalSeconds : 0;
        public DateTime Date => EndTime.HasValue ? EndTime.Value.Date : StartTime.Date;
        public string Program => $"{Path.GetFileName(Filename)} - {Title}";

    }
}
