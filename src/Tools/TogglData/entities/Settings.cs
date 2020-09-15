using System;
using System.Collections.Generic;

namespace TogglData.entities
{
    public partial class Settings
    {
        public long LocalId { get; set; }
        public long UseProxy { get; set; }
        public string ProxyHost { get; set; }
        public long? ProxyPort { get; set; }
        public string ProxyUsername { get; set; }
        public string ProxyPassword { get; set; }
        public long UseIdleDetection { get; set; }
        public string UpdateChannel { get; set; }
        public long MenubarTimer { get; set; }
        public long MenubarProject { get; set; }
        public long DockIcon { get; set; }
        public long OnTop { get; set; }
        public long Reminder { get; set; }
        public long IgnoreCert { get; set; }
        public long IdleMinutes { get; set; }
        public long FocusOnShortcut { get; set; }
        public long ReminderMinutes { get; set; }
        public long ManualMode { get; set; }
        public long AutodetectProxy { get; set; }
        public long WindowX { get; set; }
        public long WindowY { get; set; }
        public long WindowHeight { get; set; }
        public long WindowWidth { get; set; }
        public long RemindMon { get; set; }
        public long RemindTue { get; set; }
        public long RemindWed { get; set; }
        public long RemindThu { get; set; }
        public long RemindFri { get; set; }
        public long RemindSat { get; set; }
        public long RemindSun { get; set; }
        public string RemindStarts { get; set; }
        public string RemindEnds { get; set; }
        public long Autotrack { get; set; }
        public long OpenEditorOnShortcut { get; set; }
        public long HasSeenBetaOffering { get; set; }
        public long RenderTimeline { get; set; }
        public long WindowMaximized { get; set; }
        public long WindowMinimized { get; set; }
        public long WindowEditSizeHeight { get; set; }
        public long WindowEditSizeWidth { get; set; }
        public string KeyStart { get; set; }
        public string KeyShow { get; set; }
        public string KeyModifierShow { get; set; }
        public string KeyModifierStart { get; set; }
        public long KeepEndTimeFixed { get; set; }
        public long MiniTimerX { get; set; }
        public long MiniTimerY { get; set; }
        public long MiniTimerW { get; set; }
        public long Pomodoro { get; set; }
        public long PomodoroBreak { get; set; }
        public long MiniTimerVisible { get; set; }
        public long PomodoroMinutes { get; set; }
        public long PomodoroBreakMinutes { get; set; }
        public long StopEntryOnShutdownSleep { get; set; }
        public long ShowTouchBar { get; set; }
        public long MessageSeen { get; set; }
        public long ActiveTab { get; set; }
        public long ColorTheme { get; set; }
    }
}
