using System;
using System.Diagnostics;
using Topelab.Core.Helpers.Extensions;

namespace RegisterActivityServices.DTO
{
    public class ProcessDTO
    {
        public ProcessDTO(Process p, string defaultTitle)
        {
            Id = p.Id;
            MainWindowHandle = p.MainWindowHandle;
            MainWindowTitle = string.IsNullOrWhiteSpace(p.MainWindowTitle) ? defaultTitle : p.MainWindowTitle;
            ProcessName = p.ProcessName;
            StartTime = p.StartTime;
            try
            {
                FileName = p.MainModule.FileName;
            }
            catch
            {
            }
        }

        public int Id { get; set; }
        public IntPtr MainWindowHandle { get; set; }
        public string MainWindowTitle { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public string FileName { get; set; }

        public int LocalId { get; set; }
        public TimeSpan Duration { get; set; }
        public DateTime? LastTimeActive { get; set; }

        public int DurationInSeconds => (int)Duration.TotalSeconds;
        public double DurationInMinutes => Math.Round(Duration.TotalMinutes, 2);

        public override string ToString()
        {
            return this.ToJSon();
        }

        public override int GetHashCode()
        {
            return string.Concat(MainWindowTitle, ProcessName, StartTime.ToString("s")).GetHashCode();
        }
    }
}
