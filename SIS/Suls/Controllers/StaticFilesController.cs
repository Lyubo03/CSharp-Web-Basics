namespace Suls.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using System.IO;

    public class StaticFilesController
    {
        public HttpResponse BootStrap(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\bootstrap.min.css"), "text/css");
        public HttpResponse Reset(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\reset-css.css"), "text/css");
        public HttpResponse Site(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\site.css"), "text/css");
        public HttpResponse Lazy(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\lazy.css"), "text/css");
        public HttpResponse Demo(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\demo.css"), "text/css");
        public HttpResponse Text(HttpRequest request) =>
                new FileResponse(File.ReadAllBytes(@"D:\Programing flex\Web\SIS\Suls\wwwroot\css\text.css"), "text/css");
    }
}