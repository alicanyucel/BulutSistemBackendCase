
using Microsoft.Extensions.DependencyInjection;

namespace BulutSistem.Appllication
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(DependencyInjection).Assembly);
            service.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);
            });
            return service;
        }
    }
}
