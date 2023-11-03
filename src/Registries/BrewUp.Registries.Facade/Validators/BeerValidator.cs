using BrewUp.Registries.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Registries.Facade.Validators;

public sealed class BeerValidator : AbstractValidator<BeerModel>
{
    public BeerValidator()
    {
        RuleFor(v => v.BeerName).NotEmpty();
        RuleFor(v => v.BeerType).NotEmpty();
    }
}