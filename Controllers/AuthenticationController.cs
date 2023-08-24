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
using UmbracoSolarProject1.Email;
using UmbracoSolarProject1.Models;
using static OpenIddict.Abstractions.OpenIddictConstants;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Common.Security;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;
using System.Net;
using System.Web;

namespace UmbracoSolarProject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : UmbracoApiController
    {
        private readonly IConfiguration _configuration;
        private readonly UmbracoSolarProject1.Email.EmailSender _emailSender;
        private readonly AppDbContext _authContext;
        private readonly IMemberManager _memberManager;
        private readonly IMemberService _memberService;
        private readonly IMemberTypeService _memberTypeService;
        private readonly IMemberSignInManager _memberSignInManager;



        public AuthenticationController(AppDbContext dataContext, IConfiguration configuration, UmbracoSolarProject1.Email.EmailSender emailSender, IMemberManager memberManager, IMemberTypeService memberTypeService, IMemberService memberService, IMemberSignInManager memberSignInManager)
        {

            _configuration = configuration;
            _emailSender = emailSender;
            _authContext = dataContext;
            _memberManager = memberManager;
            _memberTypeService = memberTypeService;
			_memberService = memberService;
            _memberSignInManager = memberSignInManager;
        }


        [HttpPost]
		[Route("Register")]
		public async Task<IActionResult> Register([FromBody] Register model)
		{
            var memberTypeAlias = "Member";

            // Retrieve the member type
            var memberType = _memberTypeService.Get(memberTypeAlias);

            if (memberType == null)
            {
                return BadRequest("Member type not found.");
            }

            // Check if a member with the provided email already exists
            var existingMember = _memberService.GetByEmail(model.Email);

            if (existingMember != null)
            {
                return BadRequest("User with the provided email already exists.");
            }

            var identityUser = MemberIdentityUser.CreateNew(model.Email, model.Email, memberTypeAlias, isApproved: true);
            IdentityResult identityResult = await _memberManager.CreateAsync(
                identityUser,
                model.Password);

            var member = _memberService.GetByEmail(identityUser.Email);

			member.SetValue("firstName", model.FirstName);
            member.SetValue("lastName", model.LastName);
            member.SetValue("phoneNumber", model.PhoneNumber);
            
            member.IsApproved = true;

            // Save the member
            _memberService.Save(member);

            // Send registration email
            SendSuccessfullyRegisteredEmail(model.Email, model.FirstName);

            return Ok(new { Message = "User Successfully Registered" });
        }

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] Login model)
		{
            
                var user = await _memberManager.FindByNameAsync(model.Email);

                if (user == null)
                {
                    return BadRequest( "User doesn't exist.");
                }

                var passwordCorrect = await _memberManager.CheckPasswordAsync(user, model.Password);

                if (!passwordCorrect)
                {
                    return BadRequest("Password is incorrect.");
                }

                


                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    expires: DateTime.Now.AddHours(3),
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    id = user.Id,
                    firstName = user.Name,
                   

                });
            
           

        }

        [HttpGet]
        [Route("SendResetPwdLink")]
        public async Task<Object> SendResetPwdLink(string email)
        {
            
            
               
                MemberIdentityUser? user = await _memberManager.FindByEmailAsync(email);

                if (user != null)
                {
                    var token = await _memberManager.GeneratePasswordResetTokenAsync(user);

                    // email
                    var webAppUrl = _configuration["WebApp:BaseURL"];

                    var link = webAppUrl + string.Format("/reset-password/?email=" + WebUtility.UrlEncode(user.Email) + "&token=" +WebUtility.UrlEncode(token));
               
                SendResetPasswordEmail(user.Email, link, user.Name, webAppUrl);


                    return Ok(new { Message = "Reset Email Successfully sent" });
                }
                else
                {
                    // error message
                    return BadRequest("User doesn't exist.");
                }


            
           
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<Object> ResetPassword(ResetPassword resetPassword)
        {
            try
            {
                var user = await _memberManager.FindByEmailAsync(resetPassword.Id);
                if (user == null)
                {
                    return BadRequest("User not found");
                }
                var result = await _memberManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.NewPassword);

                if (!result.Succeeded)
                {
                    return BadRequest("Error");

                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error");
            }

        }

        private bool SendResetPasswordEmail(string userEmail, string url, string firstName, string webAppUrl)
        {


            var rng = new Random();

            var email = new EmailAddress();
            email.Address = userEmail;
            email.DisplayName = "Euulo";

            var emails = new EmailAddress[1];
            emails[0] = email;

            var emailBody = EmailTemplates.RESET_PASSWORD.Replace("{{user}}", firstName).Replace("{{url}}", url).Replace("{{webUrl}}", webAppUrl); ;
            var message = new EmailMessage(
                            emails,
                            "Reset Password",
                            emailBody

                        );
            _emailSender.SendEmail(message);
            return true;

        }

        private bool SendSuccessfullyRegisteredEmail(string userEmail, string firstName)
		{

			var rng = new Random();


			var email = new EmailAddress();
			email.Address = userEmail;
			email.DisplayName = "X-Solar";

			var emails = new EmailAddress[1];
			emails[0] = email;


			var message = new EmailMessage(
			   emails,
			   "Thank you for registering your interest with ",
			   EmailTemplates.SUCCESSFUL_FUNERAL_DIRECTOR_REGISTRATION.Replace("{{user}}", firstName)




		   );

			_emailSender.SendEmail(message);
			return true;

		}





	}
}
