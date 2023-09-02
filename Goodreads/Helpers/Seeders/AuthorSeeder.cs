using Goodreads.Data;
using Goodreads.Models;

namespace Goodreads.Helpers.Seeders
{
    public class AuthorSeeder
    {
        public readonly GoodreadsContext _context;

        public AuthorSeeder(GoodreadsContext context)
        {
            _context = context;
        }

        public void SeedInitialAuthors()
        {
            if (!_context.Authors.Any())
            {
                //Author1
                var author1 = new Author
                {
                    FirstName = "Ion",
                    LastName = "Creanga",
                    DateOfBirth = new DateTime(1837, 3, 1),
                    Nationality = "Romania"
                };
                //Author2
                var author2 = new Author
                {
                    FirstName = "Ana Maria",
                    LastName = "Voinea",
                    DateOfBirth = new DateTime(2002, 9, 10),
                    Nationality = "Romania"
                };
                //Author3
                var author3 = new Author
                {
                    FirstName = "Sarah",
                    LastName = "Johnson",
                    DateOfBirth = new DateTime(1980, 10, 10),
                    Nationality = "South African"
                };

                _context.Authors.Add(author1);
                _context.Authors.Add(author2);
                _context.Authors.Add(author3);

                _context.SaveChanges();
            }
        }
    }
}
