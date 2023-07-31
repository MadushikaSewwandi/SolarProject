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
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;

namespace UmbracoSolarProject1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly UmbracoSolarProject1.Email.EmailSender _emailSender;
		private readonly AppDbContext _authContext;


		public AuthenticationController(AppDbContext dataContext,IConfiguration configuration, UmbracoSolarProject1.Email.EmailSender emailSender)
		{

			_configuration = configuration;
			_emailSender = emailSender;
			_authContext = dataContext;
		}

		[HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] Register model)
		{
			var existingUser = await _authContext.Register.FirstOrDefaultAsync(u => u.Email == model.Email);
			if (existingUser != null)
			{
				return BadRequest("User with the provided email already exists.");
			}



			await _authContext.Register.AddAsync(model);
			await _authContext.SaveChangesAsync();
			return Ok(new { Message = "User Succefully Rgistered" });
		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] Login model)
		{
			try
			{

				// Find the user by email (or any unique identifier)
				var user = await _authContext.Register.FirstOrDefaultAsync(u => u.Email == model.Email);

				if (user == null)
				{
					return BadRequest("User doesn't exist.");
				}

				// Verify the password (you need to implement the password hashing and verification logic here)
				if (!VerifyPassword(model.Password, user.Password))
				{
					return BadRequest("Password is incorrect.");
				}


				// Create a new JWT token
				var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
				var token = new JwtSecurityToken(
					issuer: _configuration["JWT:Issuer"],
					audience: _configuration["JWT:Audience"],
					expires: DateTime.Now.AddHours(3)
					
				);

				return Ok(new
				{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = token.ValidTo,
					id = user.Id,
					firstName = user.FirstName,
					lastName = user.LastName
				});
			}
			catch (Exception ex)
			{
				return BadRequest("Error");
			}
		}

		// Method to verify the password (you need to implement the password hashing and verification logic here)
		private bool VerifyPassword(string enteredPassword, string hashedPassword)
		{
			// Implement your password verification logic here (e.g., using BCrypt or any other secure hashing algorithm)
			// Compare the hashedPassword with the enteredPassword after applying the same hashing algorithm.
			return hashedPassword == enteredPassword;
		}




	}
}
