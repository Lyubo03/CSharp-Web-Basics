namespace Suls
{
    using Microsoft.EntityFrameworkCore;
    using SIS.HTTP;
    using SIS.MVCFramework;
    using Suls.Controllers;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new StartUp());
        }
    }
}