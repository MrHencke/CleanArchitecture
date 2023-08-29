using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Database.Abstractions;
using ProjectName.Database.Abstractions.Repositories;
using ProjectName.Database.Repositories;

namespace ProjectName.Database.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(o => o.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

#pragma warning disable CS8603 // Possible null reference return.
            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
#pragma warning restore CS8603 // Possible null reference return.

            services.AddScoped<IExampleRepository, ExampleRepository>();

            return services;
        }
    }
}
