using Library.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
	public class _HomepageComponentPartial : ViewComponent
	{
		LibraryContext _context = new LibraryContext();	

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
