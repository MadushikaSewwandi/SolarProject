using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Umbraco.Cms.Core.IO;
using Umbraco.Cms.Core.Mail;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.Membership;
using Umbraco.Cms.Core.PropertyEditors;
using Umbraco.Cms.Core.Security;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Web.Common.Controllers;
using Umbraco.Cms.Web.Common.Security;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Models;
using Member = UmbracoSolarProject1.Models.Member;

namespace UmbracoSolarProject1.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : UmbracoApiController
    {
        private readonly IConfiguration _configuration;
        private readonly UmbracoSolarProject1.Email.EmailSender _emailSender;
        private readonly AppDbContext _authContext;
        private readonly IMemberManager _memberManager;
        private readonly IMemberService _memberService;
        private readonly IMemberTypeService _memberTypeService;
        private readonly IMemberSignInManager _memberSignInManager;



        public UserProfileController(AppDbContext dataContext, IConfiguration configuration, UmbracoSolarProject1.Email.EmailSender emailSender, IMemberManager memberManager, IMemberTypeService memberTypeService, IMemberService memberService, IMemberSignInManager memberSignInManager)
        {

            _configuration = configuration;
            _emailSender = emailSender;
            _authContext = dataContext;
            _memberManager = memberManager;
            _memberTypeService = memberTypeService;
            _memberService = memberService;
            _memberSignInManager = memberSignInManager;
        }

        [HttpGet]
        [Route("ProfileDetails/{userId}")]
        public async Task<IActionResult> ProfileDetails(int userId)
        {

            var user = await _memberManager.FindByIdAsync(userId.ToString());
            var member = _memberService.GetByEmail(user.Email);

            if (user == null)
            {
                return NotFound();
            }

            // Retrieve custom properties from the member
            string firstName = member.GetValue<string>("firstName");
            string lastName = member.GetValue<string>("lastName");
            string phoneNumber = member.GetValue<string>("phoneNumber");
            string email = member.GetValue<string>("email");

            var profileDetails = new
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                Email = email
            };

            return Ok(profileDetails);

            //int.TryParse(member.Id, out int memberId);
            //IMember callingMember = _memberService.GetById(memberId);

            //if (callingMember == null)
            //{
            //  return NotFound();
            //}

            //return Ok(callingMember);
            //turn Ok(member);
        }


        [HttpPost]
        [Route("GetProfileDetails")]
        public async Task<IActionResult> GetProfileDetails([FromBody] Member model)
        {
            try
            {
                var user = await _memberManager.FindByNameAsync(model.Email);
                var member = _memberService.GetByEmail(user.Email);

                member.SetValue("firstName", model.FirstName);
                member.SetValue("lastName", model.LastName);
                member.SetValue("phoneNumber", model.PhoneNumber);
                member.SetValue("email", model.Email);
               

                // Save the member
                _memberService.Save(member);

                return Ok(new { message = "Profile details updated successfully." });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "An error occurred while updating profile details." });
            }
        }

    }
}
