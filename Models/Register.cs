using System.ComponentModel.DataAnnotations;

namespace UmbracoSolarProject1.Models
{
	public class Register
	{
		[Key] // Add this attribute to specify the primary key
		public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Password { get; set; }
		
	}
}
