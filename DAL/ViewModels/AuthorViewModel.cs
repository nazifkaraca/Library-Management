using Library.DAL.Entities;
using System.ComponentModel.DataAnnotations;

namespace Library.DAL.ViewModels
{
    public class AuthorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Yazar adı zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Yazar soyadı zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Doğum tarihi zorunludur.")]
        public DateTime DateOfBirth { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
