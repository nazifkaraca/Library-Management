using Library.DAL.Entities;

namespace Library.Services
{
	public interface IBookService
	{
		List<Book> GetBooks(); // Get all books in a list
        Book GetBookById(int id); // Get by book id
        void BookCreate(Book book); // Create a new book
        void BookUpdate(Book book); // Update book
        void BookDelete(int id); // Delete book by id

        List<Author> GetAuthors(); // Authpr list
    }
}
