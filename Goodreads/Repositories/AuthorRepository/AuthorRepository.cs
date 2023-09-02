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
        public Author GetById2(Guid id)
        {
            return _entities.Find(id);
        }

        public async Task<IEnumerable<Author>> GetAuthorWithBooksByNameAsync(string AuthorFirstName, string AuthorLastName)
        {
            try
            {
                var query = from author in _context.Authors
                            where author.FirstName == AuthorFirstName && author.LastName == AuthorLastName
                            join book in _context.Books on author.Id equals book.AuthorId into authorBooks
                            select new Author
                            {
                                Id = author.Id,
                                FirstName = author.FirstName,
                                LastName = author.LastName,
                                Books = authorBooks.ToList() 
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        
    }
}
