using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;

namespace UmbracoSolarProject1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GetBillingDetailsController : ControllerBase
    {
        private readonly AppDbContext _authContext;

        public GetBillingDetailsController(AppDbContext dataContext)
        {
            _authContext = dataContext;
        }
        [HttpGet]
        [Route("GetBillingDetailsByUserId/{userId}")]
        public async Task<IActionResult> GetBillingDetailsByUserId(int userId)
        {
            try
            {
                // Retrieve cart items from the database for the specified user ID
                var billingDetails = await _authContext.Register.Where(c => c.Id == userId).ToListAsync();
                

                return Ok(billingDetails);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


        [HttpPost]
        [Route("AddBillingDetail")]
        public async Task<IActionResult> AddBillingDetail([FromBody] BillingDetail item)
        {
            try
            {
                // Create a new CartItem entity and set its properties
                var BillingDetail = new BillingDetail
                {
                    UserId = item.UserId,
                    Address = item.Address,
                    Country = item.Country,
                    City = item.City,
                    ZipCode = item.ZipCode
                };
                

                // Add the new CartItem entity to the CartItems DbSet
                _authContext.BillingDetail.Add(BillingDetail);

                // Save changes to the database
                await _authContext.SaveChangesAsync();

                return Ok("Item added to cart successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }


    }
}
