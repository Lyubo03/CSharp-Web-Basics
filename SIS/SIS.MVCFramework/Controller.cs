namespace Suls.Controllers
{
    using SIS.HTTP;
    using SIS.HTTP.Response;
    using System.IO;

    public abstract class Controller
    {
        private const string path = @"D:\Programing flex\Web\SIS\Suls\Views\{0}.html";
        protected HttpResponse View(string fileName)
        {
            var layout = File.ReadAllText(string.Format(path, @"Shared\layout"));
            var html = File.ReadAllText(string.Format(path, fileName));
            var result = layout.Replace("@RenderBody()", html);
            return new HtmlResponse(result);
        }

    }
}