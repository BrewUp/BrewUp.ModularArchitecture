using BrewUp.MasterData.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.MasterData.Facade.Validators;

public class PubValidator : AbstractValidator<PubModel>
{
    public PubValidator()
    {
        RuleFor(v => v.PubName).NotEmpty();
    }
}