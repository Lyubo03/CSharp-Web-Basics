namespace SIS.MVCFramework
{
    using HTTP;
    using SIS.MVCFramework.Interfaces;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class WebHost
    {
        public static async Task StartAsync(IMvcApplication application)
        {
            var routeTable = new List<Route>();

            application.ConfigureService();
            application.Configure(routeTable);

            var httpServer = new HttpServer(80, routeTable);
            await httpServer.StartAsync();
        }
    }
}