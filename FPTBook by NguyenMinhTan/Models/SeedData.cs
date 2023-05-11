using Microsoft.EntityFrameworkCore;

namespace FPTBook_by_NguyenMinhTan.Models
{
	public static class SeedData
	{
		public static void EnsurePopulated(IApplicationBuilder app)
		{
			StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

			if (context.Database.GetPendingMigrations().Any())
			{
				context.Database.Migrate();
			}

			if (!context.Products.Any())
			{
				context.Products.AddRange(
					new Product
					{
						ProductName = "Star Wars Origins: Vader.",
						ProductCategory = "Star Wars",
						ProductPrice = 120,
						ProductQuantity = 12,
						ProductDescription = "It's Vader, duh."
					},

					new Product
					{
						ProductName = "Marvel's Thanos wins.",
						ProductCategory = "Marvel",
						ProductPrice = 99,
						ProductQuantity = 596,
						ProductDescription = "When Thanos wins."
					},

					new Product
					{
						ProductName = "DC's Batman kills the Justtice League.",
						ProductCategory = "DC",
						ProductPrice = 79,
						ProductQuantity = 439,
						ProductDescription = "For those who said Batman had nothing but money."
					}
				);

				context.SaveChanges();
			}
		}
	}
}