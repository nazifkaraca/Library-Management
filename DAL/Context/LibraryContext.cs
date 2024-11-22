using Microsoft.EntityFrameworkCore;
using Library.DAL.Entities;

namespace Library.DAL.Context
{
	public class LibraryContext(DbContextOptions<LibraryContext> options) : DbContext(options)
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }
	}
}
