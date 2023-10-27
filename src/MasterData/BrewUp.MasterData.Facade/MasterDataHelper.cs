using BrewUp.MasterData.Facade.Validators;
using BrewUp.MasterData.ReadModel.Entities;
using BrewUp.MasterData.ReadModel.Queries;
using BrewUp.MasterData.ReadModel.Services;
using BrewUp.Shared.ReadModel;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BrewUp.MasterData.Facade;

public static class MasterDataHelper
{
    public static IServiceCollection AddMasterData(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<PubValidator>();
        services.AddSingleton<ValidationHandler>();
        
        services.AddScoped<IMasterDataFacade, MasterDataFacade>();
        services.AddScoped<IPubService, PubService>();
        services.AddScoped<IQueries<Pub>, PubQueries>();

        return services;
    }
}