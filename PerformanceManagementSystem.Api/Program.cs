
using PerformanceManagementSystem.Api.Extensions;
using PerformanceManagementSystem.Application;
using PerformanceManagementSystem.Infrastructure;

namespace PerformanceManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register IMediator
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
            builder.Services.AddApplicationServices();

            // Register infrastructure services with IConfiguration
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddAuthenticationService(builder.Configuration);

            var app = builder.Build();

            app.UseCors(x=>x.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin());
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ConfigureCustomExceptionMiddleware();

            app.MapControllers();

            app.Run();
        }
    }
}
