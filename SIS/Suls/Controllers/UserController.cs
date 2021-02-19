namespace Suls.Controllers
{
    using SIS.HTTP;
    using SIS.MVCFramework;

    public class UserController : Controller
    {
        public HttpResponse Login(HttpRequest request) =>
            this.View(@"Users\Login");
        
        public HttpResponse Register(HttpRequest request) =>
            this.View(@"Users\Register");
    }
}