using BulutSistem.Domain.Models;
using Microsoft.AspNetCore.Identity;

namespace BulutSistem.WebApi.Middleware;

public static class ExtensionsMiddleware
{
    public static void CreateFirstUser(WebApplication app)
    {
        using (var scoped = app.Services.CreateScope())
        {
            var userManager = scoped.ServiceProvider.GetRequiredService<UserManager<AppUser>>();

            if (!userManager.Users.Any(p => p.UserName == "admin"))
            {
                // db oluşturulurken dafault kulanıcı
                AppUser user = new()
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    FirstName = "Ali Can",
                    LastName = "Yücel",
                    EmailConfirmed = true
                };
                // token almak için kullanıcı adı : admin şifre 1 yazıyoruz
                userManager.CreateAsync(user, "1").Wait();
            }
        }
    }
}
