using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UmbracoSolarProject1.Email;
using UmbracoSolarProject1.Models;

namespace UmbracoSolarProject1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactUsController : ControllerBase
	{
		
		private readonly IConfiguration _configuration;
		private readonly UmbracoSolarProject1.Email.EmailSender _emailSender;


		public ContactUsController(IConfiguration configuration, UmbracoSolarProject1.Email.EmailSender emailSender)
		{
			
			_configuration = configuration;
			_emailSender = emailSender;
		} 

		[HttpPost]
		[Route("ContactUsForm")]
		public async Task<bool> ContactUsForm([FromBody] ContactUsForm model)
		{
			
			var email = new EmailAddress();
			email.Address = model.Email;
			email.DisplayName = "XSolar";
			

			var emails = new EmailAddress[1];
			emails[0] = email;

			var emailBody = EmailTemplates.SA_ALERT_NEW_CONTACT_FORM_SUBMISSION
				.Replace("{{user}}", model.Name)
				.Replace("{{email}}", model.Email)
				.Replace("{{subject}}", model.Subject)
				.Replace("{{message}}", model.Message);
				

			var message = new EmailMessage(
			emails,
			 "New Contact Form Submission",
			  emailBody

						);
			_emailSender.SendEmail(message);
			return true;

		}
	}
}
