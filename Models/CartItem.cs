namespace UmbracoSolarProject1.Models
{
	public class CartItem
	{
		public string Id { get; set; }
		public int CartId { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public int Quantity { get; set; }
		public string ProductThumbnail { get; set; }
		public string ProductLink { get; set; }
	}
}
