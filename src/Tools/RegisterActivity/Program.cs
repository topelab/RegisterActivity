using System;
using Topelab.Core.Resolver.Interfaces;
using Topelab.Core.Resolver.Microsoft;

namespace RegisterActivity
{
    internal class Program
    {
        private static IResolver resolver;
        private static IProcessService processService;

        private static void Main(string[] args)
        {
            Prepare();
            Console.WriteLine("Register activities\nPress <Esc> to exit");
            bool exit = false;
            while (!exit)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                {
                    exit = true;
                    processService.Stop();
                }
            }
        }

        static void Prepare()
        {
            resolver = ResolverFactory.Create(SetupDI.Register());
            processService = resolver.Get<IProcessService>();
            IDataService dataService = resolver.Get<IDataService>();
            processService.Start(dataService.SaveData);
        }
    }
}
