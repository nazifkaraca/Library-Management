using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kitap adı zorunludur.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Yazar bilgisi zorunludur.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Kitap türü zorunludur.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Yayınlanma tarihi zorunludur.")]
        public DateTime PublishDate { get; set; }

        [Required(ErrorMessage = "ISBN bigisi zorunludur.")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Stok durumu zorunludur.")]
        public int CopiesAvailable { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; } // DropDownList için
    }
}
