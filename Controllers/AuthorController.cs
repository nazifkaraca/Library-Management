using Library.DAL.Entities;
using Library.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorService _context;

        public AuthorController(IAuthorService context)
        {
            _context = context;
        }

        // Güncelleme sayfasını açar (GET)
        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var author = _context.GetAuthorById(id);

            if (author == null)
            {
                return NotFound(); // Eğer ID eşleşen bir yazar bulunmazsa
            }

            return View(author); // Yazar modelini View'e gönder
        }

        // Güncelleme işlemini yapar (POST)
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            if (ModelState.IsValid) // Model doğrulama kontrolü
            {
                _context.AuthorUpdate(author); // Güncelleme işlemini yap
                return RedirectToAction("Index", "Home"); // Güncelleme sonrası ana sayfaya yönlendir
            }

            // Hata varsa aynı formu tekrar göster
            return View(author);
        }

        // Örnek: Yazar Listesi
        public IActionResult Index()
        {
            var authors = _context.GetAuthors(); // Tüm yazarları getir
            return View(authors); // Yazar listesini View'e gönder
        }

    }
}
