using Goodreads.Data;
using Goodreads.Models;
using Goodreads.Models.DTOs;
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
        public BookController(GoodreadsContext goodreadsContext) 
        {
            _goodreadsContext = goodreadsContext;
        }

        [HttpGet("get-books")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _goodreadsContext.Books.ToListAsync());
        }

        [HttpGet("bookById/{id}")]
        public async Task<IActionResult> GetBooksById([FromRoute] Guid id)
        {
            var bookById = from book in _goodreadsContext.Books
                           where book.Id == id
                           select book;
            return Ok(bookById);
        }

        [HttpPost("CreateBook")]
        public async Task<IActionResult> CreateBook(BookDTO bookDTO)
        {
            var newBook = new Book();
            newBook.BookTitle = bookDTO.BookTitle;
            newBook.Author = bookDTO.Author;
            newBook.BookDescription = bookDTO.BookDescription;
            newBook.ReleaseDate = bookDTO.ReleaseDate;

            await _goodreadsContext.AddAsync(newBook);
            await _goodreadsContext.SaveChangesAsync();
            return Ok(newBook);
        }
    }
}
