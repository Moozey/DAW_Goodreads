using Goodreads.Models;
using Goodreads.Repositories.GenericRepository;

namespace Goodreads.Repositories.BookRepository
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        Book FindById(Guid id);
        Task<ICollection<Book>> GetAllBooks();
        Book FindBookByTitle(string bookTitle);
        ICollection<Book> FindBookByRealeaseYear(int realeaseYear);
        Task<IEnumerable<Book>> GetBooksByAuthorNameAsync(string AuthorFirstName, string AuthorLastName);
    }
}
