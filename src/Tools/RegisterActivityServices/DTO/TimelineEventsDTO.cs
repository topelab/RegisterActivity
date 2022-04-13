using System;
using System.IO;

namespace RegisterActivityServices.DTO
{
    public partial class TimelineEventsDTO
    {
        public long LocalId { get; set; }
        public string Title { get; set; }
        public string Filename { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double TotalTime { get; set; }
        public string Program => $"{Path.GetFileName(Filename)} - {Title}";
    }
}
