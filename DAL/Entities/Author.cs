using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string LastName { get; set; }

        public required DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
