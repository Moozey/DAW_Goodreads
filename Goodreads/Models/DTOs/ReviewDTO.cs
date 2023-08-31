using System.ComponentModel.DataAnnotations;

namespace Goodreads.Models.DTOs
{
    public class ReviewDTO
    {
        
        [Required]
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public float Rating { get; set; }
    }
}
