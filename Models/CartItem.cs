using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace UmbracoSolarProject1.Models
{
	public class CartItem
	{
<<<<<<< HEAD

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public string? ProductThumbnail { get; set; }
        public string? ProductLink { get; set; }

        public Register? Register { get; set; }
    
=======
		
		public int Id { get; set; }
		public int UserId { get; set; }
		public string? ProductName { get; set; }
		public decimal? ProductPrice { get; set; }
		public int? Quantity { get; set; }
		public string? ProductThumbnail { get; set; }
		public string? ProductLink { get; set; }

		public Register? Register { get; set; }
>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5
	}
}
