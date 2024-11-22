using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
	public class _AboutComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
