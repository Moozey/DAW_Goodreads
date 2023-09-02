using Goodreads.Models;
using Goodreads.Models.DTOs;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.BookRepository
{
    public interface IBookRepository : IGenericRepository<Book>
    {

        Task<ICollection<Book>> GetAllBooks();
        Book FindBookByTitle(string bookTitle);
        ICollection<Book> FindBookByRealeaseYear(int realeaseYear);
        Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string AuthorFirstName, string AuthorLastName);
    } 
}
