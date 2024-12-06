using System.ComponentModel.DataAnnotations;

namespace Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public string ISBN { get; set; }

        [Required]
        public int CopiesAvailable { get; set; }

        public Author? Author { get; set; }
	}
}
