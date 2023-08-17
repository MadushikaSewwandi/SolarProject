using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace UmbracoSolarProject1.Models
{
	public class CartItem
	{

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? ProductName { get; set; }
        public decimal? ProductPrice { get; set; }
        public int? Quantity { get; set; }
        public string? ProductThumbnail { get; set; }
        public string? ProductLink { get; set; }

       
    
		
	}
}
