using Goodreads.Base;

namespace Goodreads.Models
{
    public class Book: BaseEntity
    {
        public string BookTitle { get; set; }
        public string? BookDescription { get; set; }
        public Guid? AuthorId { get; set; }
        public Author? Author { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public ICollection<BookGenre>? BookGenre { get; set; }
    }
}
