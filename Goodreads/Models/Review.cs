using Goodreads.Base;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Goodreads.Models
{
    public class Review: BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public string Title { get; set; }
        public string? ReviewDetails { get; set; }

        // value should be between 1.0 and 10.0
        [Range(0, 10)]
        public float Rating { get; set; }
    }
}
