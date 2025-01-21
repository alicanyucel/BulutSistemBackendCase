using BulutSistem.Domain.Models;
using BulutSistem.Infrastructure.DataContext;
using Castle.Core.Configuration;
using GenericRepository;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;

namespace BulutSistem.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
       
        services.AddIdentity<AppUser, AppRole>(action =>
        {
            action.Password.RequiredLength = 1;
            action.Password.RequireUppercase = false;
            action.Password.RequireLowercase = false;
            action.Password.RequireNonAlphanumeric = false;
            action.Password.RequireDigit = false;
        }).AddEntityFrameworkStores<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(srv => srv.GetRequiredService<ApplicationDbContext>());
        services.Scan(action =>
        { // isimler aynın oldugu sürece optomatik olarak dinjection yapar
            action.FromAssemblies(typeof(DependencyInjection).Assembly).AddClasses(publicOnly: false).UsingRegistrationStrategy(registrationStrategy: RegistrationStrategy.Skip).AsImplementedInterfaces().WithScopedLifetime();
        });

        return services;
    }
}