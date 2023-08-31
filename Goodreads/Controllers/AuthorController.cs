using Goodreads.Data;
using Goodreads.Models.DTOs;
using Goodreads.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Goodreads.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private GoodreadsContext _goodreadsContext;
        public AuthorController(GoodreadsContext goodreadsContext)
        {
            _goodreadsContext = goodreadsContext;
        }

        [HttpGet("getAuthors")]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _goodreadsContext.Authors.ToListAsync());
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
    }
}
