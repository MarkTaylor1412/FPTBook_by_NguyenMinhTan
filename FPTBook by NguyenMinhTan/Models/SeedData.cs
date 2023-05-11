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
						ProductName = "Taylor",
						ProductCategory = "Sci-fi",
						ProductPrice = 12,
						ProductQuantity = 12,
						ProductDescription = "Very Cool."
					},

					new Product
					{
						ProductName = "Taylor",
						ProductCategory = "Sci-fi",
						ProductPrice = 12,
						ProductQuantity = 12,
						ProductDescription = "Very Cool."
					},

					new Product
					{
						ProductName = "Taylor",
						ProductCategory = "Sci-fi",
						ProductPrice = 12,
						ProductQuantity = 12,
						ProductDescription = "Very Cool."
					}
				);

				context.SaveChanges();
			}
		}
	}
}