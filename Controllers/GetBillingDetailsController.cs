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
                var billingDetails = await _authContext.BillingDetail.Where(c => c.UserId == userId).ToListAsync();
                

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
                // Check if a billing detail record already exists for the given UserId
                var existingBillingDetail = await _authContext.BillingDetail
                    .FirstOrDefaultAsync(b => b.UserId == item.UserId);

                if (existingBillingDetail != null)
                {
                    // Update the existing billing detail record with the new data
                    existingBillingDetail.Address = item.Address;
                    existingBillingDetail.Country = item.Country;
                    existingBillingDetail.City = item.City;
                    existingBillingDetail.ZipCode = item.ZipCode;
                    existingBillingDetail.FirstName = item.FirstName;
                    existingBillingDetail.LastName = item.LastName;
                    existingBillingDetail.Email = item.Email;
                    existingBillingDetail.Telephone = item.Telephone;
                }
                else
                {
                    // Create a new BillingDetail entity and set its properties
                    var newBillingDetail = new BillingDetail
                    {
                        UserId = item.UserId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Telephone = item.Telephone,
                        Address = item.Address,
                        Country = item.Country,
                        City = item.City,
                        ZipCode = item.ZipCode
                    };

                    // Add the new BillingDetail entity to the BillingDetail DbSet
                    _authContext.BillingDetail.Add(newBillingDetail);
                }

                // Save changes to the database
                await _authContext.SaveChangesAsync();

                return Ok("Billing detail added or updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }



    }
}
