using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using ProjectName.Domain.Behavior;
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
            services.AddFluentValidationAutoValidation();
            services.AddFluentValidationClientsideAdapters();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));


            return services;
        }
    }
}
