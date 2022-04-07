using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RegisterActivity
{
    internal class WindowTools
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

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
    }
}
