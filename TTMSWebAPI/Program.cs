using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TTMSWebAPI
{
    /// <summary>
    /// 主类
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 主方法
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build();

           host.Run();
        }
    }
}
