using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FPTBook_by_NguyenMinhTan.Models
{
    public static class IdentitySeedData
    {
        private const string adminUsername = "Taylor";
        private const string adminPassword = "T@n1412";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            AppIdentityDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<AppIdentityDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser user = await userManager.FindByNameAsync(adminUsername);
            if (user == null)
            {
                user = new IdentityUser("Taylor");
                user.Email = "tan12@gmail.com";
                user.PhoneNumber = "1900-8989";
                await userManager.CreateAsync(user, adminPassword);
            }
        }
    }
}
