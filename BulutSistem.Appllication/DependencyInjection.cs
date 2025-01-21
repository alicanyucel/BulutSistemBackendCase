using BulutSistem.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using BulutSistem.Appllication.Behaviors;

namespace BulutSistem.Appllication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
         
            services.AddAutoMapper(typeof(DependencyInjection).Assembly);

            services.AddMediatR(conf =>
            {
                conf.RegisterServicesFromAssemblies(
                    typeof(DependencyInjection).Assembly,
                    typeof(AppUser).Assembly);
                conf.AddOpenBehavior(typeof(ValidationBehavior<,>));
            });

            services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}