using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
