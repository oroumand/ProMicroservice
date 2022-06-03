using Earth.Core.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Commands;
using Earth.Core.Contracts.ApplicationServices.Events;
using Earth.Core.Contracts.ApplicationServices.Queries;
using FluentValidation;
using System.Reflection;

namespace Earth.Endpoints.WebApi.Extentions.DependencyInjection;

public static class AddApplicationServicesExtentions
{
    public static IServiceCollection AddZaminApplicationServices(
        this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services
            .AddCommandHandlers(assembliesForSearch)
            .AddCommandDispatcherDecorators()
            .AddQueryHandlers(assembliesForSearch)
            .AddEventHandlers(assembliesForSearch)
            .AddFluentValidators(assembliesForSearch);

    private static IServiceCollection AddCommandHandlers(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(ICommandHandler<>), typeof(ICommandHandler<,>));

    private static IServiceCollection AddCommandDispatcherDecorators(this IServiceCollection services)
    {
        services.AddTransient<CommandDispatcher, CommandDispatcher>();
        services.AddTransient<CommandDispatcherDomainExceptionHandlerDecorator, CommandDispatcherDomainExceptionHandlerDecorator>();
        services.AddTransient<CommandDispatcherValidationDecorator, CommandDispatcherValidationDecorator>();
        services.AddTransient<ICommandDispatcher, CommandDispatcherValidationDecorator>();
        return services;
    }

    private static IServiceCollection AddQueryHandlers(this IServiceCollection services,
        IEnumerable<Assembly> assembliesForSearch) =>
        services.AddWithTransientLifetime(assembliesForSearch, typeof(IQueryHandler<,>), typeof(IQueryDispatcher));

    private static IServiceCollection AddEventHandlers(this IServiceCollection services,
       IEnumerable<Assembly> assembliesForSearch) =>
       services.AddWithTransientLifetime(assembliesForSearch, typeof(IDomainEventHandler<>), typeof(IEventDispatcher));

    private static IServiceCollection AddFluentValidators(this IServiceCollection services,
    IEnumerable<Assembly> assembliesForSearch) =>
    services.AddValidatorsFromAssemblies(assembliesForSearch);
}
