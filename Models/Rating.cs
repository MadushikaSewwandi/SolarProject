using System.ComponentModel.DataAnnotations;

namespace UmbracoSolarProject1.Models
{
	public class Rating
	{
		[Key] // Add this attribute to specify the primary key
		public int Id { get; set; }

		public string? ProductName { get; set; }

		public string? Name { get; set; }

		public string? Email { get; set; }

		public string? Review { get; set; }

		public int RatingValue { get; set; }
	}
}
