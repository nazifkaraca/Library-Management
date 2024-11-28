using Library.DAL.Entities;

namespace Library.Services
{
    public interface IAuthorService
    {
        List<Author> GetAuthors(); // Yazar listesini getir
        Author GetAuthorById(int id); // Belirli bir yazarı ID'ye göre getir
        void AuthorCreate(Author author); // Yeni bir yazar ekle
        void AuthorUpdate(Author author); // Yazar bilgilerini güncelle
        void AuthorDelete(int id); // Yazar sil
        ICollection<Book> AuthorBooks(Author author);
    }
}
