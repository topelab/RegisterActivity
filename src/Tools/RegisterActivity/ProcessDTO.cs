using System;

namespace RegisterActivity
{
    internal class ProcessDTO
    {
        public ProcessDTO(int id, string mainWindowTitle, string processName, DateTime startTime, string fileName)
        {
            Id = id;
            MainWindowTitle = mainWindowTitle;
            ProcessName = processName;
            StartTime = startTime;
            FileName = fileName;
        }

        public int Id { get; set; }
        public string MainWindowTitle { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public string FileName { get; set; }
    }
}
