using Microsoft.AspNetCore.Mvc;

namespace Library.Views.ViewComponents
{
    public class _AboutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
