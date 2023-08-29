using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ProjectName.Api.Extensions
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ProjectName Api",
                    Description = "An api for ProjectName",
                    Contact = new OpenApiContact
                    {
                        Name = "Creator Name",
                        Email = "Creator Email",
                        Url = new Uri("https://example.com")
                    }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
