using Library.DAL.Entities;

namespace Library.Services
{
    public interface IAuthorService
    {
        List<Author> GetAuthors(); // Get all authors in a list
        Author GetAuthorById(int id); // Get by author id
        void AuthorCreate(Author author); // Create a new author
        void AuthorUpdate(Author author); // Update author
        void AuthorDelete(int id); // Delete author by id
        ICollection<Book> AuthorBooks(Author author); // Book collection of an author
    }
}
