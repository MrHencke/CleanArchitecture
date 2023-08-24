using ProjectName.Api.Extensions;
using ProjectName.Database.Extensions;
using ProjectName.Domain.Extensions;

namespace ProjectName.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services from other projects
            builder.Services.AddDatabaseServices(builder.Configuration);
            builder.Services.AddDomainServices();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagger();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.MapControllers();

            app.Run();
        }
    }
}