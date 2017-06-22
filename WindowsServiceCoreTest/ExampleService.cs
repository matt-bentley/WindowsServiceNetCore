using Microsoft.Extensions.PlatformAbstractions;
using PeterKottas.DotNetCore.WindowsService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace WindowsServiceCoreTest
{
    public class ExampleService : IMicroService
    {
        private string fileName = @"C:\Repo\WindowsServiceCoreTest\WindowsServiceCoreTest\bin\Debug\netcoreapp1.1\log.txt";
        public void Start()
        {
            Console.WriteLine("I started");
            Console.WriteLine(fileName);
                  
        }

        public void Stop()
        {
            File.AppendAllText(fileName, "Stopped\n");
            Console.WriteLine("I stopped");
        }
    }
}
