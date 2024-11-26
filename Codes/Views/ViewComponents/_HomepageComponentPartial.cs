using Library.DAL.Context;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Views.ViewComponents
{
    public class _HomepageComponentPartial : ViewComponent
    {
        public readonly IAuthorService authorService;
        public readonly IBookService bookService;

        public _HomepageComponentPartial(IAuthorService authorService, IBookService bookService)
        {
            this.authorService = authorService;
            this.bookService = bookService;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.Authors = authorService.GetAuthors();
            ViewBag.Books = bookService.GetBooks();

            return View();
        }
    }
}
