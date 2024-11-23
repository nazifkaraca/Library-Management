using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Yazar ID'si zorunludur.")]
        public required int AuthorId { get; set; }

        [Required(ErrorMessage = "Kitap türü zorunludur.")]
        public required string Genre { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi zorunludur.")]
        public required DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN bigisi zorunludur.")]
        public required string ISBN { get; set; }

        [Required(ErrorMessage = "Stok durumu zorunludur.")]
        public required int CopiesAvailable { get; set; }

		public Author Author { get; set; }
	}
}
