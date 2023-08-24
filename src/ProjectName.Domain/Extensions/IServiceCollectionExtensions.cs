using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ProjectName.Domain.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddMediatR(c => 
            {
                c.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            return services;
        }
    }
}
