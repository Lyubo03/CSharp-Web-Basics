namespace SIS.MVCFramework.Interfaces
{
    using HTTP;
    using System.Collections.Generic;

    public interface IMvcApplication
    {
        void Configure(IList<Route> routeTable);
        void ConfigureService();
    }
}