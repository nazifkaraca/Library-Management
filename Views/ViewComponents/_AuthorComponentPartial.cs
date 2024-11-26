using Library.DAL.Context;
using Library.DAL.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Views.ViewComponents
{
    public class _AuthorComponentPartial : ViewComponent
    {
        private readonly IAuthorService _context;

        public _AuthorComponentPartial(IAuthorService context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var authors = _context.GetAuthors();
            return View(authors);
        }
    }
}
