using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Models.DTOs;
using Goodreads.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private GoodreadsContext _goodreadsContext;
        private readonly IBookService _bookService;
        public BookController(GoodreadsContext goodreadsContext, IBookService bookService) 
        {
            _goodreadsContext = goodreadsContext;
            _bookService = bookService;
        }

        [HttpGet("get-books")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _goodreadsContext.Books.ToListAsync());
        }

        //[HttpGet("bookById1/{id}")]
        //public async Task<IActionResult> GetBooksById([FromRoute] Guid id)
        //{
        //    var bookById = from book in _goodreadsContext.Books
        //                   where book.Id == id
        //                   select book;
        //    return Ok(bookById);
        //}

        [HttpGet("bookById/{id}")]
        public ActionResult<Book> GetBookById(Guid id) 
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine("afterthis");
            return Ok(book);
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(BookDTO bookDTO)
        {
            var newBook = new Book();
            newBook.BookTitle = bookDTO.BookTitle;
            newBook.BookDescription = bookDTO.BookDescription;
            newBook.ReleaseDate = bookDTO.ReleaseDate;

            await _goodreadsContext.AddAsync(newBook);
            await _goodreadsContext.SaveChangesAsync();
            return Ok(newBook);
        }

        [HttpPut("updateBook/{id}")]
        public IActionResult UpdateBook(Guid id, BookDTO book)
        {
            var bookToUpdate = _bookService.GetBookById(id);
            if (bookToUpdate == null)
            {
                return BadRequest("The book Id could not be found!");
            }
            bookToUpdate.BookTitle = book.BookTitle;
            bookToUpdate.BookDescription = book.BookDescription;

            _bookService.Save();
            return Ok();
        }
        [HttpDelete("bookById/{id}")]
        public ActionResult DeleteBookById(Guid id)
        {
            var bookToDelete = _bookService.GetBookById(id);
            if (bookToDelete == null)
            {
                return BadRequest("The book Id could not be found!");
            }
            _bookService.DeleteBook(bookToDelete);
            _bookService.Save();

            return Ok();
        }


    }
}
