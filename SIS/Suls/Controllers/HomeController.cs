namespace Suls.Controllers
{
    using SIS.HTTP;
    using SIS.MVCFramework;

    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request) =>
            this.View(@"Home\index");

    }
}