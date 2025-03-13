using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            // Register MediatR (CQRS Handlers)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
