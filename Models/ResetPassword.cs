namespace UmbracoSolarProject1.Models
{
    public class ResetPassword
    {
        public string Id { get; set; }
        public string NewPassword { get; set; }
        public string confirmPassword { get; set; }
        public string Token { get; set; }
    }
}
