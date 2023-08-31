using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Repositories.BookRepository;
using Goodreads.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly GoodreadsContext _context;
        public AuthorRepository(GoodreadsContext context) : base(context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            try
            {
                List<Author> authors = await _context.Authors.ToListAsync();
                return authors;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Author>> GetAuthorWithBooksByNameAsync(string AuthorFirstName, string AuthorLastName)
        {
            var authorsWithBooks = from a in _entities
                                   where a.FirstName == AuthorFirstName && a.LastName == AuthorLastName
                                   select a;

            return (ICollection<Author>)authorsWithBooks;
        }

    }
}
