using BrewUp.Infrastructures.RabbitMq;
using BrewUp.Registries.Facade.Validators;
using BrewUp.Registries.Infrastructures.RabbitMq;
using BrewUp.Registries.ReadModel.Entities;
using BrewUp.Registries.ReadModel.Queries;
using BrewUp.Registries.ReadModel.Services;
using BrewUp.Shared.ReadModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.Registries.Facade;

public static class RegistriesHelper
{
    public static IServiceCollection AddRegistries(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<PubValidator>();
        services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<IRegistriesFacade, RegistriesFacade>();
        services.AddScoped<IPubService, PubService>();
        services.AddScoped<IQueries<Pub>, PubQueries>();
        services.AddScoped<IBeerService, BeerService>();
        services.AddScoped<IQueries<Beer>, BeerQueries>();

        return services;
    }

    public static IServiceCollection AddRegistriesInfrastructure(this IServiceCollection services,
        RabbitMqSettings rabbitMqSettings)
    {
        services.AddRabbitMqForRegistriesModule(rabbitMqSettings);
        
        return services;
    }
}