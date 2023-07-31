using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace UmbracoSolarProject1.Controllers
{
	[Authorize]
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
				// Check if the user is authenticated
				if (!User.Identity.IsAuthenticated)
				{
					return Unauthorized(new { message = "You need to log in to add items to the cart." });
				}

				

				// Save the cart item details along with the user ID to the database
				var cartItem = new CartItem
				{
					
					ProductName = item.ProductName,
					ProductPrice = item.ProductPrice,
					ProductThumbnail = item.ProductThumbnail,
					Quantity = item.Quantity,
					ProductLink = item.ProductLink
				};

				// Find if the item is already in the cart for the logged-in user
				var existingCartItem = _authContext.CartItems
					.FirstOrDefault(i => i.ProductName == item.ProductName );

				if (existingCartItem != null)
				{
					// If the item is already in the cart, update its quantity
					existingCartItem.Quantity += item.Quantity;
				}
				else
				{
					// If the item is not in the cart, add it as a new item
					
					_authContext.CartItems.Add(cartItem);
				}

				_authContext.SaveChanges();

				return Ok(new { message = "Item added to the cart successfully." });
			}
			catch (Exception ex)
			{
				// Handle any exceptions that occur during cart item addition
				return BadRequest(new { message = "Error adding item to cart: " + ex.Message });
			}
		}

	}
}
