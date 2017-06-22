using Microsoft.Extensions.PlatformAbstractions;
using PeterKottas.DotNetCore.WindowsService.Base;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WindowsServiceCoreTest
{
    public class ExampleServiceTimer : MicroService, IMicroService
    {
        private string fileName = Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "log.txt");
        public void Start()
        {
            StartBase();
            Timers.Start("Poller", 1000, () =>
            {
                File.AppendAllText(fileName, string.Format("Polling at {0}\n", DateTime.Now.ToString("o")));
            });
            Console.WriteLine("I started");
            File.AppendAllText(fileName, "Started\n");
        }

        public void Stop()
        {
            StopBase();
            File.AppendAllText(fileName, "Stopped\n");
            Console.WriteLine("I stopped");
        }
    }
}
