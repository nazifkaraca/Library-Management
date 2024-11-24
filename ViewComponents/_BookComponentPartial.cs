using Library.DAL.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Versioning;

namespace Library.ViewComponents
{
	public class _BookComponentPartial : ViewComponent
	{
		private readonly IBookService _bookService;

		public _BookComponentPartial(IBookService bookService)
		{
			_bookService = bookService;
		}

		public IViewComponentResult Invoke()
		{
			var books = _bookService.GetBooks();

			return View(books);
		}
	}
}
