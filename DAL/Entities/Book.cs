namespace Library.DAL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public required string Genre { get; set; }
        public required DateTime PublishDate { get; set; }
        public required string ISBN { get; set; } 
        public required int CopiesAvailable { get; set; }

		public Author Author { get; set; }
	}
}
