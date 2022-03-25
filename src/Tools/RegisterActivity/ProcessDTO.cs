using System;

namespace RegisterActivity
{
    internal class ProcessDTO
    {
        public ProcessDTO(string mainWindowTitle, string processName, DateTime startTime, string fileName)
        {
            MainWindowTitle = mainWindowTitle;
            ProcessName = processName;
            StartTime = startTime;
            FileName = fileName;
        }

        public string MainWindowTitle { get; set; }
        public string ProcessName { get; set; }
        public DateTime StartTime { get; set; }
        public string FileName { get; set; }
    }
}
