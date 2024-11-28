﻿using Library.DAL.Entities;
using Library.Services;
using Library.DAL.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Runtime.Intrinsics.Arm;


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

            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth
            };

            return View(model); // Yazar modelini View'e gönder
        }

        // Güncelleme işlemini yapar (POST)
        [HttpPost]
        public IActionResult UpdateAuthor(Author author)
        {
            _context.AuthorUpdate(author); // Güncelleme işlemini yap

            return Redirect("/#authors"); // Güncelleme sonrası ana sayfaya yönlendir
        }


        [HttpGet]
        public IActionResult CreateAuthor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                return View(author); // Hatalıysa aynı formu geri döndür
            }

            _context.AuthorCreate(author); // Yazar bilgilerini kaydet
            ModelState.Clear();
            TempData["SuccessMessage"] = "Yazar başarıyla eklendi!"; // Başarı mesajı ekle
            return Redirect("/#authors"); // Sayfayı sıfırlamak için yeniden yönlendir
        }

        public IActionResult DeleteAuthor(int id)
        {
            _context.AuthorDelete(id);
            return Redirect("/#authors");
        }

        [HttpGet]
        public IActionResult DetailAuthor(int id)
        {
            var author = _context.GetAuthorById(id);
            var book = _context.AuthorBooks(author);

            var model = new AuthorViewModel
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirth = author.DateOfBirth,
                Books = book
            };
            return View(model);
        }

        // Örnek: Yazar Listesi
        public IActionResult Index()
        {
            var authors = _context.GetAuthors(); // Tüm yazarları getir
            return View(authors); // Yazar listesini View'e gönder
        }
    }
}
