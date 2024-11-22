using Microsoft.EntityFrameworkCore;
using Library.DAL.Entities;

namespace Library.DAL.Context
{
	public class LibraryContext : DbContext
	{
		public DbSet<Author> Authors { get; set; }
		public DbSet<Book> Books { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=localhost;Database=LibraryDatabase;Trusted_Connection=True;TrustServerCertificate=True");
			}
		}

	}
}
