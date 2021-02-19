namespace Suls
{
    using SIS.HTTP;
    using SIS.MVCFramework;
    using Controllers;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SIS.MVCFramework.Interfaces;

    public class StartUp : IMvcApplication
    {
        public void Configure(IList<Route> routeTable)
        {
            routeTable.Add(new Route(HttpMethodType.Get, "/", new HomeController().Index));
            routeTable.Add(new Route(HttpMethodType.Get, "/vendor/bootstrap/bootstrap.min.css", new StaticFilesController().BootStrap));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/site.css", new StaticFilesController().Site));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/reset-css.css", new StaticFilesController().Reset));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/lazy.css", new StaticFilesController().Lazy));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/demo.css", new StaticFilesController().Demo));
            routeTable.Add(new Route(HttpMethodType.Get, "/css/text.css", new StaticFilesController().Text));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Login", new UserController().Login));
            routeTable.Add(new Route(HttpMethodType.Get, "/Users/Register", new UserController().Register));
        }

        public void ConfigureService()
        {
            var context = new ApplicationDbContext();
            context.Database.Migrate();
        }
    }
}