using Library.DAL.Entities;

namespace Library.Services
{
	public interface IBookService
	{
		List<Book> GetAllBooks();
		Book GetBookById(int id);
		void BookCreate(Book book);
		void BookUpdate(int id);
		void BookDelete(int id);
	}
}
