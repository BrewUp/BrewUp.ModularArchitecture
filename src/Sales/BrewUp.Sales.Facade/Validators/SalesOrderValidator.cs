using BrewUp.Shared.Contracts;
using FluentValidation;

namespace BrewUp.Sales.Facade.Validators;

public class SalesOrderValidator : AbstractValidator<SalerOrderJson>
{
    public SalesOrderValidator()
    {
        RuleFor(v => v.SalesOrderNumber).NotEmpty();
        RuleFor(v => v.PubId).NotEqual(Guid.Empty);
        RuleFor(v => v.OrderDate).GreaterThan(DateTime.MinValue);

        RuleForEach(v => v.Rows).SetValidator(new SalesOrderLineValidator());
    }
}