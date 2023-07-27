using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Umbraco.Cms.Infrastructure.Mail;
using UmbracoSolarProject1.Email;
using EmailSender = UmbracoSolarProject1.Email.EmailSender;


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

			// Other services and dependencies can be added here
			// ...

		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
		}
	}
}
