using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UmbracoSolarProject1.Models;

namespace UmbracoSolarProject1.Data
{
	public class AppDbContext:DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

			



        }

        public DbSet<Register> Register { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Rating> Rating { get; set; }
        public DbSet<BillingDetail> BillingDetail { get; set; }
    }
}
