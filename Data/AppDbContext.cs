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

<<<<<<< HEAD
            builder.Entity<CartItem>()
           .HasOne(c => c.Register)      // Cart has one Register
                 .WithMany()                   // Register has many Carts
                 .HasForeignKey(c => c.UserId)  // Define the foreign key property
                 .OnDelete(DeleteBehavior.Cascade);
=======
			builder.Entity<CartItem>()
		   .HasOne(c => c.Register)      // Cart has one Register
		   .WithMany()                   // Register has many Carts
		   .HasForeignKey(c => c.UserId)  // Define the foreign key property
		   .OnDelete(DeleteBehavior.Cascade);

>>>>>>> 00b850c98c6009f4be022f430b2c7e4b286586e5



        }

        public DbSet<Register> Register { get; set; }
		public DbSet<CartItem> CartItems { get; set; }

        public DbSet<Rating> Rating { get; set; }
        public DbSet<BillingDetail> BillingDetail { get; set; }
    }
}
