namespace SIS.MVCFramework.Interfaces
{
    public interface IViewEngine
    {
        string GetHtml(string template, object model);
    }
}