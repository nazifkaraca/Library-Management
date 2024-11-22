using Library.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
	public class _AuthorComponentPartial : ViewComponent
	{
		LibraryContext _context = new LibraryContext();

		public IViewComponentResult Invoke()
		{
			var authors = _context.Authors.ToList();
			return View(authors);
		}
	}
}
