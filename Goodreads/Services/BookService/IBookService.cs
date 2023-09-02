using Goodreads.Models;
using Goodreads.Models.DTOs;

namespace Goodreads.Services.BookService
{
    public interface IBookService
    {
        Book GetBookById(Guid id);
        Task<ICollection<Book>> GetAllBooks();
        Task<Book> AddBook(BookDTO newBook);
        Task DeleteBook(Book bookToDelete);
        Task<Book> UpdateBookService(BookDTO bookToUpdate, Guid id);
        bool Save();

    }
}
