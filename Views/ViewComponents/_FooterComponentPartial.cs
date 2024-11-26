using Microsoft.AspNetCore.Mvc;

namespace Library.Views.ViewComponents
{
    public class _FooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
