using Goodreads.Base;
using System.ComponentModel.DataAnnotations;

namespace Goodreads.Models
{
    public class Genre: BaseEntity
    {
        [Required]
        public string GenreName { get; set; }
        public ICollection<BookGenre>? BookGenre { get; set; }
    }
}
