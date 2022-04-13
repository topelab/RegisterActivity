using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RegisterActivityServices.Tools
{
    internal class WindowTools
    {
        [DllImport("user32.dll")]
        internal static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern IntPtr SetWinEventHook(int eventMin, int eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, int idProcess, int idThread, int dwflags);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern int UnhookWinEvent(IntPtr hWinEventHook);

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

        internal delegate void WinEventProc(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        public static string GetActiveWindowTitle()
        {
            const int nChars = 512;
            var Buff = new StringBuilder(nChars);
            var handle = GetForegroundWindow();
            return GetWindowText(handle, Buff, nChars) > 0 ? Buff.ToString() : null;
        }

        public static int GetActiveWindowProcessId()
        {
            var handle = GetForegroundWindow();
            GetWindowThreadProcessId(handle, out var processId);
            return (int)processId;
        }
    }
}
