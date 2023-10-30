using BrewUp.Shared.Contracts;
using FluentValidation;

namespace BrewUp.Sales.Facade.Validators;

public class SalesOrderLineValidator : AbstractValidator<SalesOrderRowJson>
{
    public SalesOrderLineValidator()
    {
        RuleFor(v => v.BeerId).NotEqual(Guid.Empty);
        RuleFor(v => v.BeerName).NotEmpty();

        RuleFor(v => v.Quantity.Value).GreaterThan(0);
        RuleFor(v => v.Quantity.UnitOfMeasure).NotEmpty();

        RuleFor(v => v.Price.Value).GreaterThan(0);
        RuleFor(v => v.Price.Currency).NotEmpty();
    }
}