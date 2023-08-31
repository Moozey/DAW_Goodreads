using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Repositories.BookRepository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly GoodreadsContext _context;
        public BookRepository(GoodreadsContext context) : base(context) 
        {
            _context = context;
          
        }

        public ICollection<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }



        public Book FindBookByTitle(string bookTitle)
        {
            return _entities.FirstOrDefault(x => x.BookTitle == bookTitle);
        }


        public ICollection<Book> FindBookByRealeaseYear(int realeaseYear)
        {
            var books = from b in _entities
                        where b.ReleaseDate.Year == realeaseYear
                        select b;

            return (ICollection<Book>)books;
        }


        public async Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string AuthorFirstName, string AuthorLastName)
        {
            return await _context.Books
                .Include(a => a.Author)
                .Where(a => a.Author.FirstName == AuthorFirstName && a.Author.LastName == AuthorLastName)
                .ToListAsync();
        }


    }
}
