using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Models.DTOs;
using Goodreads.Repositories.BookRepository;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Services.BookService
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public Book GetBookById(Guid id)
        {
            return _bookRepository.FindById(id);
        }

        public async Task<ICollection<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllBooks();
        }

        public async Task<Book> AddBook(BookDTO newBook)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                BookTitle = newBook.BookTitle
            };
            _bookRepository.Create(book);
            if (await _bookRepository.SaveAsync())
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public async Task DeleteBook(Book bookToDelete)
        {
            _bookRepository.Delete(bookToDelete);
            await _bookRepository.SaveAsync();
        }


        public async Task<Book> UpdateBook(BookDTO bookToUpdate, Guid id)
        {
            var book = _bookRepository.FindById(id);
            if (book == null)
            {
                throw new ArgumentException($"Book not found!");
            }

            book.BookTitle = bookToUpdate.BookTitle;

            _bookRepository.Update(book);
            if (await _bookRepository.SaveAsync())
            {
                return book;
            }
            else
            {
                return null;
            }
        }

        public bool Save()
        {
            return _bookRepository.Save();
        }
    }
}
