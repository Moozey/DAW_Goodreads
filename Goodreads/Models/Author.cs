using Goodreads.Base;
using System.ComponentModel.DataAnnotations;

namespace Goodreads.Models
{
    public class Author: BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Nationality { get; set; }

        //books that this author wrote
        public ICollection<Book>? Books { get; set; }
        //users who have this authors as their favourite
        public ICollection<User>? Users { get; set; }
    }
}
