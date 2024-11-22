using Library.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
	public class _HomepageComponentPartial : ViewComponent
	{
		public readonly LibraryContext _context;

		public _HomepageComponentPartial(LibraryContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
