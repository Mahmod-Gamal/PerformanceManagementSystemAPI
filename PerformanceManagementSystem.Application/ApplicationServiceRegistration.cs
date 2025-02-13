using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using PerformanceManagementSystem.Application.Behaviors;
using PerformanceManagementSystem.Application.Features.Duration.Commands.AddDuration;
using FluentValidation;

namespace PerformanceManagementSystem.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            // Register FluentValidation and automatically scan for validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            return services;
        }
    }
}