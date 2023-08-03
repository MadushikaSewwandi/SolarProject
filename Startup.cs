using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Umbraco.Cms.Infrastructure.Mail;
using UmbracoSolarProject1.Data;
using UmbracoSolarProject1.Email;
using EmailSender = UmbracoSolarProject1.Email.EmailSender;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace UmbracoSolarProject1
{
	public class Startup
	{
		private readonly IWebHostEnvironment _env;
		private readonly IConfiguration _config;

		public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
		{
			Configuration = configuration;
			_env = webHostEnvironment;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddUmbraco(_env, Configuration)
				.AddBackOffice()
				.AddWebsite()
				.AddDeliveryApi()
				.AddComposers()
				.Build();

			// Register the email configuration from appsettings.json
			var emailConfig = Configuration.GetSection("EmailConfiguration").Get<EmailConfigurations>();
			services.AddSingleton(emailConfig);

			// Register the EmailSender service
			services.AddSingleton<EmailSender>();
			services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("umbracoDbDSN")));

			services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			})
		   .AddJwtBearer(options =>
		   {
			   options.SaveToken = true;
			   options.RequireHttpsMetadata = true;
			   options.TokenValidationParameters = new TokenValidationParameters()
			   {
				   ValidateIssuer = true,
				   ValidateAudience = false,
				   ValidAudience = Configuration["Jwt:Audience"],
				   ValidIssuer = Configuration["Jwt:Issuer"],
				   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
			   };
		   }
		   );

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env,AppDbContext context)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseUmbraco()
				.WithMiddleware(u =>
				{
					u.UseBackOffice();
					u.UseWebsite();
				})
				.WithEndpoints(u =>
				{
					u.UseInstallerEndpoints();
					u.UseBackOfficeEndpoints();
					u.UseWebsiteEndpoints();
				});
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
		}
	}
}
