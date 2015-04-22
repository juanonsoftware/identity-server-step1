using Microsoft.Owin.Hosting;
using System;
using Thinktecture.IdentityServer.Core.Logging;

namespace IdentityDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new DiagnosticsTraceLogProvider());

            using (WebApp.Start<Startup>("http://localhost:44333"))
            {
                Console.WriteLine("server running...");
                Console.ReadLine();
            }
        }
    }
}
