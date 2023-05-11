using Microsoft.EntityFrameworkCore;
using FPTBook_by_NguyenMinhTan.Models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts => {
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:FPTBookConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagination", "Products/Page{ProductPage}", new { Controller = "Home", action = "Index" });

app.MapControllerRoute("catpage",
					   "{category}/Page{productPage:int}",
					   new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
					   "Page{productPage:int}",
					   new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapControllerRoute("category",
					   "{category}",
					   new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapControllerRoute("pagination",
					   "Products/Page{productPage}",
					   new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapDefaultControllerRoute();

SeedData.EnsurePopulated(app);

app.Run();