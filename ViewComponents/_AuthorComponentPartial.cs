using Library.DAL.Context;
using Microsoft.AspNetCore.Mvc;

namespace Library.ViewComponents
{
	public class _AuthorComponentPartial : ViewComponent
	{
		private readonly LibraryContext _context;

		public _AuthorComponentPartial(LibraryContext context)
		{
			_context = context;
		}

		public IViewComponentResult Invoke()
		{
			var authors = _context.Authors.ToList();
			return View(authors);
		}
	}
}
