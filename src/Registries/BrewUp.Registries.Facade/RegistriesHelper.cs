using BrewUp.MasterData.ReadModel.Entities;
using BrewUp.MasterData.ReadModel.Queries;
using BrewUp.MasterData.ReadModel.Services;
using BrewUp.Registries.Facade.Validators;
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
}