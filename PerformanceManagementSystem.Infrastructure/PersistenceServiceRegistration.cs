using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using PerformanceManagementSystem.Application.Interfaces.Identity;
using PerformanceManagementSystem.Application.Interfaces.Persistence;
using PerformanceManagementSystem.Application.Interfaces.Email;
using PerformanceManagementSystem.Infrastructure.Email;
using PerformanceManagementSystem.Infrastructure.Identity;
using PerformanceManagementSystem.Infrastructure.Persistence.DataInitializer;
using PerformanceManagementSystem.Infrastructure.Persistence.Repositories;
using System.Text;
using Microsoft.EntityFrameworkCore.Diagnostics;
using PerformanceManagementSystem.Infrastructure.Persistence.Interceptors;


namespace PerformanceManagementSystem.Infrastructure
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDataInitializer, DataInitializer>();

            services.AddDbContext<PerformanceManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PerformanceManagementDbConnection")));
            services.AddSingleton<AuditingSaveChangesInterceptor>();


            // Build the service provider to resolve the DbContext and initialize the database
            var serviceProvider = services.BuildServiceProvider();
            using (var scope = serviceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<PerformanceManagementDbContext>();
                // Ensure the database is created and migrated
                dbContext.Database.EnsureCreated();
            }
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IJwtProvider, JwtProvider>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPasswordManager, PasswordManager>();
            services.AddHttpContextAccessor();

            return services;
        }
        public static IServiceCollection AddAuthenticationService(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection("JWTOptions"));
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = configuration["JWTOptions:Issuer"],
                        ValidAudience = configuration["JWTOptions:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWTOptions:SecretKey"]))
                    };
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;

                            if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/Notifications") || path.StartsWithSegments("/CoreResponseCodeSignal")))
                            {
                                context.Token = accessToken;
                            }

                            return Task.CompletedTask;
                        }
                    };
                }
               );
            return services;
        }

    }
}
