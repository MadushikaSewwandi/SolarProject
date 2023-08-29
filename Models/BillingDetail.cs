using Newtonsoft.Json;

namespace UmbracoSolarProject1.Models
{
    public class BillingDetail
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public int ZipCode { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }
        public string? Email { get; set; }

        public int? Telephone { get; set; }


        
    }
}
