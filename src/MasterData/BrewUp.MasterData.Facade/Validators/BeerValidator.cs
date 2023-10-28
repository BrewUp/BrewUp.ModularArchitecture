using BrewUp.MasterData.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.MasterData.Facade.Validators;

public sealed class BeerValidator : AbstractValidator<BeerModel>
{
    public BeerValidator()
    {
        RuleFor(v => v.BeerName).NotEmpty();
        RuleFor(v => v.BeerType).NotEmpty();
    }
}