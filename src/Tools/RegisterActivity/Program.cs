using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace RegisterActivity
{
    internal class Program
    {
        private static Timer timer;
        private static bool stopNow;

        private static void Main(string[] args)
        {
            Prepare();
            Console.WriteLine("Register activities\nPress <Esc> to exit");
            bool exit = false;
            while (!exit)
            {
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    exit = true;
                    stopNow = true;
                    timer.Dispose();
                }
            }
        }

        static void Prepare()
        {
            stopNow = false;
            timer = new Timer(CheckProcesses, stopNow, 0, 5000);
        }

        private static void CheckProcesses(object state)
        {
            var processes = Process.GetProcesses().Where(p => !string.IsNullOrWhiteSpace(p.MainWindowTitle)).Select(p => new { p.MainWindowTitle, p.ProcessName, p.StartTime, p.MainModule.FileName });
            Console.WriteLine(JsonConvert.SerializeObject(processes, Formatting.None));
        }
    }
}
