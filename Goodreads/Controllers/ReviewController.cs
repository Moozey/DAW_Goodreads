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
    public class ReviewController : ControllerBase
    {
        private GoodreadsContext _goodreadsContext;
        public ReviewController(GoodreadsContext goodreadsContext)
        {
            _goodreadsContext = goodreadsContext;
        }
        [HttpGet("getReviews")]
        public async Task<IActionResult> GetAllReviews()
        {
            return Ok(await _goodreadsContext.Reviews.ToListAsync());
        }

        [HttpPost("CreateReview")]
        public async Task<IActionResult> CreateReview(ReviewDTO reviewDTO)
        {
            var newReview = new Review();
            newReview.BookId = reviewDTO.BookId;
            newReview.Title = reviewDTO.Title;
            newReview.Rating = reviewDTO.Rating;

            await _goodreadsContext.AddAsync(newReview);
            await _goodreadsContext.SaveChangesAsync();
            return Ok(newReview);
        }
    }
}
