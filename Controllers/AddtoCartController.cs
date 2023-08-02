using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Org.BouncyCastle.Bcpg;
using Umbraco.Cms.Core.Models.Membership;

namespace UmbracoSolarProject1.Controllers
{
	
	[Route("api/[controller]")]
	[ApiController]
	public class AddtoCartController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly UmbracoSolarProject1.Email.EmailSender _emailSender;
		private readonly AppDbContext _authContext;

		public AddtoCartController(AppDbContext dataContext,IConfiguration configuration, UmbracoSolarProject1.Email.EmailSender emailSender)
		{

			_configuration = configuration;
			_emailSender = emailSender;
			_authContext = dataContext;
		}

		[HttpPost]
		[Route("AddItem")]
		public async Task<IActionResult> AddItem([FromBody] CartItem item)
		{
			try
			{
				

				// Add the item to the context and save changes to the database
				await _authContext.CartItems.AddAsync(item);
				await _authContext.SaveChangesAsync();

				// Return a success response
				return Ok(new { Message = "Item added to the cart successfully." });
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during cart item addition
				return BadRequest(new { Message = "Error adding item to cart: " + ex.Message });
			}
		}

	}
}
