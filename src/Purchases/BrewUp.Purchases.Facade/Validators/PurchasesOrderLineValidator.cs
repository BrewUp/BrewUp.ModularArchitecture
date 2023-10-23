using BrewUp.Purchases.Facade.BindingModels;
using FluentValidation;

namespace BrewUp.Purchases.Facade.Validators;

public class PurchasesOrderLineValidator : AbstractValidator<PurchasesOrderLineJson>
{
    public PurchasesOrderLineValidator()
    {
        RuleFor(v => v.BeerId).NotEqual(Guid.Empty);
        RuleFor(v => v.BeerName).NotEmpty();

        RuleFor(v => v.Quantity.Value).GreaterThan(0);
        RuleFor(v => v.Quantity.UnitOfMeasure).NotEmpty();

        RuleFor(v => v.Price.Value).GreaterThan(0);
        RuleFor(v => v.Price.Currency).NotEmpty();
    }
}