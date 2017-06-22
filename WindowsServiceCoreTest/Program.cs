using PeterKottas.DotNetCore.WindowsService;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using System;
using System.IO;
using System.Threading;

namespace WindowsServiceCoreTest
{
    public class Program
    {
        private static string fileName = @"C:\Repo\WindowsServiceCoreTest\WindowsServiceCoreTest\bin\Debug\netcoreapp1.1\log.txt";
        public static void Main(string[] args)
        {
            ServiceRunner<ExampleService>.Run(config =>
            {
                var name = config.GetDefaultName();
                config.Service(serviceConfig =>
                {
                    serviceConfig.ServiceFactory((extraArguments) =>
                    {
                        return new ExampleService();
                    });

                    serviceConfig.OnStart((service, extraParams) =>
                    {
                        Console.WriteLine("Service {0} started", name);
                        service.Start();
                    });

                    serviceConfig.OnStop(service =>
                    {
                        Console.WriteLine("Service {0} stopped", name);
                        service.Stop();
                    });

                    serviceConfig.OnError(e =>
                    {
                        Console.WriteLine("Service {0} errored with exception : {1}", name, e.Message);
                    });
                });
            });

            while (true)
            {
                File.AppendAllText(fileName, $"Processed:{DateTime.Now}\n");
                Thread.Sleep(5000);
            }
        }
    }
}