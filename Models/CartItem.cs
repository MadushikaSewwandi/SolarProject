namespace UmbracoSolarProject1.Models
{
	public class CartItem
	{
		public string UserId { get; set; }
		public string Id { get; set; }
		public string ProductName { get; set; }
		public string ProductPrice { get; set; }
		public int Quantity { get; set; }
		public string ProductThumbnail { get; set; }
		public string ProductLink { get; set; }
	}
}
