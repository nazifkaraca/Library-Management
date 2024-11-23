using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Author
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Yazar soyadı zorunludur.")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
