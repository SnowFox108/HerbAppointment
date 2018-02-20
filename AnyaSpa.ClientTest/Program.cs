using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AnyaSpa.ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            var configConnection = new ConfigConnection(configuration);

            new TestConnection(configConnection);

            Console.ReadKey();
        }
    }
}
