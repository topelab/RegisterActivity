using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RegisterActivity
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

        public static (IntPtr intPtr, string title) GetActiveWindowTitle()
        {
            const int nChars = 512;
            IntPtr handle = IntPtr.Zero;
            StringBuilder Buff = new StringBuilder(nChars);
            handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return (handle, Buff.ToString());
            }
            return (IntPtr.Zero, null);
        }
        public static (IntPtr intPtr, int processId) GetActiveWindowProcessId()
        {
            IntPtr handle = GetForegroundWindow();
            GetWindowThreadProcessId(handle, out uint processId);
            return (handle, (int)processId);
        }
    }
}
