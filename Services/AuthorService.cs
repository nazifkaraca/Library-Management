using Library.DAL.Context;
using Library.DAL.Entities;

namespace Library.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly LibraryContext _context;

        public AuthorService(LibraryContext context)
        {
            _context = context;
        }

        public void AuthorCreate(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AuthorDelete(int id)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == id);

            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Yazar bulunamadı.");
            }
        }

        public void AuthorUpdate(Author author)
        {
            var existingAuthor = _context.Authors.FirstOrDefault(x => x.Id == author.Id);

            if (existingAuthor != null)
            {
                existingAuthor.FirstName = author.FirstName;
                existingAuthor.LastName = author.LastName;
                existingAuthor.DateOfBirth = author.DateOfBirth;

                _context.SaveChanges();
            }
            else
            {
                throw new KeyNotFoundException("Yazar bulunamadı.");
            }
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.FirstOrDefault(x => x.Id == id);
        }

        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList(); // Veritabanındaki tüm yazarları liste olarak döndür
        }
    }
}



