using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
    public class _ScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
