using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Umbraco.Cms.Core.Models.Membership;


namespace UmbracoSolarProject1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : Controller
    {
        private readonly AppDbContext _authContext;

        public RatingsController(AppDbContext dataContext)
        {
            _authContext = dataContext;
        }
        [HttpPost]
        [Route("AddRate")]
        public async Task<IActionResult> AddRate([FromBody] Rating item)
        {
            try
            {
                // Create a new CartItem entity and set its properties
                var Rating = new Rating
                {
                    Id = item.Id,
                    ProductName = item.ProductName,
                    RatingValue = item.RatingValue,
                    Name=item.Name,
                    Email=item.Email,
                    Review=item.Review
                    
                };

                // Add the new CartItem entity to the CartItems DbSet
                _authContext.Rating.Add(Rating);

                // Save changes to the database
                await _authContext.SaveChangesAsync();

                return Ok("Item added to cart successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

       [HttpGet]
        [Route("GetRatingsByProductName")]
        public async Task<IActionResult> GetRatingsByProductName()
        {
            try
            {

               // var ratings = await _authContext.Rating.Where(x => x.ProductName == productName).ToListAsync();


                // Get all ratings for the specified product name
                var ratings = await _authContext.Rating.ToListAsync();

                var ratingsArray = ratings.Select(x => new {
                    name = x.Name,
                    review = x.Review,
                    productname = x.ProductName,
                    ratingvalue = x.RatingValue,
                    email =x.Email
                }).ToList();

                // Return the ratings
                return Ok(ratingsArray);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}
