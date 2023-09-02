using Goodreads.Data;
using Goodreads.Models.DTOs;
using Goodreads.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Goodreads.Services.BookService;
using Goodreads.Services.AuthorService;
using System.Diagnostics;

namespace Goodreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private GoodreadsContext _goodreadsContext;
        private readonly IAuthorService _authorService;
        public AuthorController(GoodreadsContext goodreadsContext, IAuthorService authorService)
        {
            _goodreadsContext = goodreadsContext;
            _authorService = authorService;
        }

        [HttpGet("getAuthors")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _goodreadsContext.Authors.ToListAsync());
        }
        

        [HttpGet("{id}", Name = "GetAuthorById")]
        public ActionResult<Author> GetDirectorById(Guid id)
        {
            var director = _authorService.getAuthorById2(id);
            if (director == null)
            {
                return NotFound();
            }
            System.Diagnostics.Debug.WriteLine("afterthis");
            return Ok(director);
        }


        [HttpPost("CreateAuthor")]
        public async Task<IActionResult> CreateBook(AuthorDTO authorDTO)
        {
            var newAuthor = new Author();
            newAuthor.FirstName = authorDTO.FirstName;
            newAuthor.LastName = authorDTO.LastName;
            newAuthor.Nationality = authorDTO.Nationality;
            newAuthor.DateOfBirth = authorDTO.DateOfBirth;

            await _goodreadsContext.AddAsync(newAuthor);
            await _goodreadsContext.SaveChangesAsync();
            return Ok(newAuthor);
        }

        [HttpDelete("authorById/{id}")]
        public ActionResult DeleteAuthorById(Guid id)
        {
            var authorToDelete = _authorService.getAuthorById2(id);
            if (authorToDelete == null)
            {
                return BadRequest("The book ID was not found!");
            }
            _authorService.DeleteAuthor(authorToDelete);
            _authorService.Save();

            return Ok();
        }
        
    }
}
