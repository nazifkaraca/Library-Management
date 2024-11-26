using Microsoft.AspNetCore.Mvc;

namespace Library.Views.ViewComponents
{
    public class _ScriptsComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
