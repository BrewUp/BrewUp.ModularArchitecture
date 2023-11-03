using BrewUp.Registries.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Registries.Facade.Validators;

public class PubValidator : AbstractValidator<PubModel>
{
    public PubValidator()
    {
        RuleFor(v => v.PubName).NotEmpty();
    }
}