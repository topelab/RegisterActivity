﻿using System;
using System.Diagnostics;

namespace RegisterActivity
{
    internal class ProcessDTO
    {
        public ProcessDTO(Process p) : this(p.Id, p.MainWindowHandle, p.MainWindowTitle, p.ProcessName, p.StartTime, p.MainModule.FileName)
        {
        }

        public ProcessDTO(int id, IntPtr mainWindowHandle, string mainWindowTitle, string processName, DateTime startTime, string fileName)
        {
            Id = id;
            MainWindowHandle = mainWindowHandle;
            MainWindowTitle = mainWindowTitle;
            ProcessName = processName;
            StartTime = startTime;
            FileName = fileName;
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
    }
}
