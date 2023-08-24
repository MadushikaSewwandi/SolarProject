using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace UmbracoSolarProject1.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AddtoCartController : ControllerBase
	{
		private readonly AppDbContext _authContext;

		public AddtoCartController(AppDbContext dataContext)
		{
			_authContext = dataContext;
		}

		[HttpPost]
		[Route("AddItem")]
		public async Task<IActionResult> AddItem([FromBody] CartItem item)
		{
			try
			{
				// Create a new CartItem entity and set its properties
				var cartItem = new CartItem
				{
					UserId = item.UserId,
					ProductName = item.ProductName,
					ProductPrice = item.ProductPrice,
					Quantity = item.Quantity,
					ProductThumbnail = item.ProductThumbnail,
					ProductLink = item.ProductLink
				};

				// Add the new CartItem entity to the CartItems DbSet
				_authContext.CartItems.Add(cartItem);

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
		[Route("GetCartItemsByUserId/{userId}")]
		public async Task<IActionResult> GetCartItemsByUserId(int userId)
		{
			try
			{
				// Retrieve cart items from the database for the specified user ID
				var cartItems = await _authContext.CartItems.Where(c => c.UserId == userId).ToListAsync();

				return Ok(cartItems);
			}
			catch (Exception ex)
			{
				return BadRequest("Error: " + ex.Message);
			}
		}

		[HttpDelete]
		[Route("DeleteCartItem/{itemId}")]
		public async Task<IActionResult> DeleteCartItem(int itemId)
		{
			try
			{
				
				var cartItem = await _authContext.CartItems.FindAsync(itemId);
				if (cartItem == null)
				{
					return NotFound("Cart item not found.");
				}

				
				_authContext.CartItems.Remove(cartItem);

				
				await _authContext.SaveChangesAsync();

				return Ok("Cart item deleted successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest("Error: " + ex.Message);
			}
		}


	}
}
