using Microsoft.EntityFrameworkCore;
using FPTBook_by_NguyenMinhTan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);





// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(opts =>
	opts.UseSqlServer(builder.Configuration["ConnectionStrings:FPTBookConnection"]));

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();
builder.Services.AddScoped<IOrderRepository, EFOrderRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddServerSideBlazor();

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
	options.UseSqlServer(builder.Configuration["ConnectionStrings:IdentityConnection"]));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
	.AddEntityFrameworkStores<AppIdentityDbContext>();

var app = builder.Build();

if (app.Environment.IsProduction())
{
	app.UseExceptionHandler("/error");
}

app.UseRequestLocalization(opts =>
{
	opts.AddSupportedCultures("en-GB")
	.AddSupportedCultures("en-GB")
	.SetDefaultCulture("en-GB");
});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute("pagination",
						"Products/Page{ProductPage}",
						new { Controller = "Home", action = "Index" });

app.MapControllerRoute("catpage",
						"{category}/Page{ProductPage:int}",
						new { Controller = "Home", action = "Index" });

app.MapControllerRoute("page",
						"Page{ProductPage:int}",
						new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapControllerRoute("category",
						"{category}",
						new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapControllerRoute("pagination",
						"Products/Page{ProductPage}",
						new { Controller = "Home", action = "Index", ProductPage = 1 });

app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

SeedData.EnsurePopulated(app);
IdentitySeedData.EnsurePopulated(app);

app.Run();