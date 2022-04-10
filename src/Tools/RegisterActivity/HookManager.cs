using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace RegisterActivity
{
    internal class HookManager : IProcessService
    {
        public void Start(Action<ProcessDTO> onNewProcesses)
        {
            this.onNewProcesses = onNewProcesses;
            SubscribeToWindowEvents();
        }

        public void Stop()
        {
            if (windowEventHook != IntPtr.Zero)
            {
                if (WindowTools.UnhookWinEvent(windowEventHook) != 0)
                {
                    windowEventHook = IntPtr.Zero;
                }
                else
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }
        }

        private void SubscribeToWindowEvents()
        {
            if (windowEventHook == IntPtr.Zero)
            {
                windowEventHook = WindowTools.SetWinEventHook(
                    EVENT_SYSTEM_FOREGROUND, // eventMin
                    EVENT_SYSTEM_FOREGROUND, // eventMax
                    IntPtr.Zero,             // hmodWinEventProc
                    WindowEventCallback,     // lpfnWinEventProc
                    0,                       // idProcess
                    0,                       // idThread
                    WINEVENT_OUTOFCONTEXT | WINEVENT_SKIPOWNPROCESS);

                if (windowEventHook == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }
            }

            Application.Run();
        }

        private void WindowEventCallback(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime)
        {
            ProcessDTO currentProcess = null;

            try
            {
                var processId = WindowTools.GetActiveWindowProcessId();
                currentProcess = new ProcessDTO(Process.GetProcessById(processId));
            }
            catch { }
            finally
            {
                if (previousProcess != null)
                {
                    onNewProcesses?.Invoke(previousProcess);
                }
                previousProcess = currentProcess;
            }
        }

        private IntPtr windowEventHook;

        private const int WINEVENT_OUTOFCONTEXT = 0;
        private const int WINEVENT_SKIPOWNPROCESS = 2;

        private const int EVENT_SYSTEM_FOREGROUND = 3;

        private Action<ProcessDTO> onNewProcesses;
        private ProcessDTO previousProcess;
    }
}
