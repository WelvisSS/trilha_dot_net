using MediatR;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using CleanArchitecture.Application.Shared.Behavior;
using System.Reflection;


namespace CleanArchtecture.Application.Services;
public static class ServiceExtensions
{
    public static void ConfigureApplicationApp(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}