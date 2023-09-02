using System.ComponentModel.DataAnnotations;

namespace Goodreads.Models.DTOs
{
    public class BookDTO
    {
        [Required]
        public string BookTitle { get; set; }
        public string BookDescription { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Guid AuthorId { get; set; }
    }
}
