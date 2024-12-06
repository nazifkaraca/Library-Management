using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class DefaultController : Controller
    {
        /// <summary>
        /// Default index to host views.
        /// </summary>
        /// <returns>View of hosted views.</returns>
        public IActionResult Index()
        {
            return View();
        }
    }
}
