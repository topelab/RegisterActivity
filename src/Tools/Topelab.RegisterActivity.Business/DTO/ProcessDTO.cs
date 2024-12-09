using System;
using Topelab.Core.Domain.Extensions;

namespace Topelab.RegisterActivity.Business.DTO
{
    public class ProcessDTO
    {
        public int Id { get; set; }
        public IntPtr MainWindowHandle { get; set; }
        public string MainWindowTitle { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public string FileName { get; set; }

        public int LocalId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? LastTimeActive { get; set; }
        public double Discount { get; set; }

        public int DurationInSeconds => (int)Duration.TotalSeconds;
        public double DurationInMinutes => Math.Round(Duration.TotalMinutes, 2);

        public override string ToString()
        {
            return this.ToJSon();
        }

        public override int GetHashCode()
        {
            return string.Concat(MainWindowTitle, ProcessName).GetHashCode();
        }
    }
}
